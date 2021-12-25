using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    private int playerId;

    public void SetupObject(int playerId)
    {
        this.playerId = playerId;
        
        GameObject baseObject = transform.GetChild(0).gameObject;
        GameObject middleObject = transform.GetChild(1).gameObject;
        GameObject topObject = transform.GetChild(2).gameObject;

        Material primaryMaterial = Resources.Load("Materials/Player" + playerId + "Primary") as Material;
        Material accentMaterial = Resources.Load("Materials/Player" + playerId + "Accent") as Material;
        
        baseObject.GetComponent<Renderer>().material = accentMaterial;
        middleObject.GetComponent<Renderer>().material = primaryMaterial;
        topObject.GetComponent<Renderer>().material = accentMaterial;
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