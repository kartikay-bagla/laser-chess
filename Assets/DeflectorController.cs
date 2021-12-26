using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeflectorController : PieceController
{

    override public void ApplyMaterials(Material primaryMaterial, Material accentMaterial)
    {
        GameObject baseObject = transform.GetChild(0).gameObject;
        GameObject middleObject = transform.GetChild(1).gameObject;
        GameObject topObject = transform.GetChild(3).gameObject;
        GameObject capsuleObject = transform.GetChild(4).gameObject;

        baseObject.GetComponent<Renderer>().material = accentMaterial;
        middleObject.GetComponent<Renderer>().material = primaryMaterial;
        topObject.GetComponent<Renderer>().material = accentMaterial;
        capsuleObject.GetComponent<Renderer>().material = primaryMaterial;
    }

    override public Direction GetHitByLaser(Direction laserDirection)
    {
        Debug.Log("Hit a deflector!");

        Direction laserDirectionRelativeToNorth = RotateRelativeToNorth(laserDirection);

        if (laserDirectionRelativeToNorth == Direction.South) {
            return UnrotateRelativeToNorth(Direction.East);
        }
        else if (laserDirectionRelativeToNorth == Direction.West) {
            return UnrotateRelativeToNorth(Direction.North);
        }

        return Direction.None;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}