using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderController : PieceController
{

    override public void ApplyMaterials(Material primaryMaterial, Material accentMaterial)
    {
        GameObject baseObject = transform.GetChild(0).gameObject;
        GameObject middleObject = transform.GetChild(1).gameObject;
        GameObject middle2Object = transform.GetChild(2).gameObject;
        GameObject topObject = transform.GetChild(3).gameObject;

        baseObject.GetComponent<Renderer>().material = accentMaterial;
        middleObject.GetComponent<Renderer>().material = accentMaterial;
        middle2Object.GetComponent<Renderer>().material = accentMaterial;
        topObject.GetComponent<Renderer>().material = primaryMaterial;
    }

    override public Direction GetHitByLaser(Direction laserDirection) {
        Debug.Log("Hit a defender!");

        Direction laserDirectionRelativeToNorth = RotateRelativeToNorth(laserDirection);
        if (laserDirectionRelativeToNorth != Direction.South) {
            // TODO: Kill the Defender
            Debug.Log("Defender was killed!");
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