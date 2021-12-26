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

    public override Direction GetHitByLaser(int rowDelta, int columnDelta)
    {
        if (direction == Direction.North)
        {
            if (rowDelta == 1)
            {
                return Direction.East;
            }
            else if (columnDelta == -1)
            {
                return Direction.North;
            }
        }
        else if (direction == Direction.South)
        {
            if (rowDelta == -1)
            {
                return Direction.West;
            }
            else if (columnDelta == 1)
            {
                return Direction.South;
            }
        }
        else if (direction == Direction.West)
        {
            if (rowDelta == 1)
            {
                return Direction.West;
            }
            else if (columnDelta == 1)
            {
                return Direction.North;
            }
        }
        else if (direction == Direction.East)
        {
            if (rowDelta == -1)
            {
                return Direction.South;
            }
            else if (columnDelta == -1)
            {
                return Direction.East;
            }
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