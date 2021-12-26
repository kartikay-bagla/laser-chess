using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : PieceController
{

    override public void ApplyMaterials(Material primaryMaterial, Material accentMaterial)
    {
        GameObject baseObject = transform.GetChild(0).gameObject;
        GameObject middleObject = transform.GetChild(1).gameObject;
        GameObject topObject = transform.GetChild(3).gameObject;

        baseObject.GetComponent<Renderer>().material = accentMaterial;
        middleObject.GetComponent<Renderer>().material = primaryMaterial;
        topObject.GetComponent<Renderer>().material = accentMaterial;
    }

    override public Direction GetHitByLaser(Direction laserDirection) {
        Direction laserDirectionRelativeToNorth = RotateRelativeToNorth(laserDirection);

        Debug.Log("Hit a switch!");

        if (laserDirectionRelativeToNorth == Direction.North) {
            return UnrotateRelativeToNorth(Direction.West);
        }
        else if (laserDirectionRelativeToNorth == Direction.East) {
            return UnrotateRelativeToNorth(Direction.South);
        }
        else if (laserDirectionRelativeToNorth == Direction.South) {
            return UnrotateRelativeToNorth(Direction.East);
        }
        else if (laserDirectionRelativeToNorth == Direction.West) {
            return UnrotateRelativeToNorth(Direction.North);
        }
        else {
            return Direction.None;
        }
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
