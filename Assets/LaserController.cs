using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : PieceController
{

    override public void ApplyMaterials(Material primaryMaterial, Material accentMaterial)
    {
        GameObject baseObject = transform.GetChild(0).gameObject;
        GameObject middleObject = transform.GetChild(1).gameObject;
        GameObject topObject = transform.GetChild(2).gameObject;

        baseObject.GetComponent<Renderer>().material = accentMaterial;
        middleObject.GetComponent<Renderer>().material = primaryMaterial;
        topObject.GetComponent<Renderer>().material = accentMaterial;
    }

    override public Direction GetHitByLaser(Direction laserDirection) {
        Debug.Log("Hit a laser!");
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