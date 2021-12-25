using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderController : MonoBehaviour
{
    private int playerId;

    public void SetupObject(int playerId)
    {
        this.playerId = playerId;
        
        GameObject baseObject = transform.GetChild(0).gameObject;
        GameObject middleObject = transform.GetChild(1).gameObject;
        GameObject middle2Object = transform.GetChild(2).gameObject;
        GameObject topObject = transform.GetChild(3).gameObject;

        Material primaryMaterial = Resources.Load("Materials/Player" + playerId + "Primary") as Material;
        Material accentMaterial = Resources.Load("Materials/Player" + playerId + "Accent") as Material;
        
        baseObject.GetComponent<Renderer>().material = accentMaterial;
        middleObject.GetComponent<Renderer>().material = accentMaterial;
        middle2Object.GetComponent<Renderer>().material = accentMaterial;
        topObject.GetComponent<Renderer>().material = primaryMaterial;
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