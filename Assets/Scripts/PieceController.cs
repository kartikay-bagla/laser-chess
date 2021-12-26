using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{

    private Player playerType;

    public void SetupObject(Player playerType, Direction direction)
    {
        this.playerType = playerType;
        int playerId = (int)playerType;

        Material primaryMaterial = Resources.Load("Materials/Player" + playerId + "Primary") as Material;
        Material accentMaterial = Resources.Load("Materials/Player" + playerId + "Accent") as Material;

        ApplyMaterials(primaryMaterial, accentMaterial);

        if (direction == Direction.North)
        {
            transform.Rotate(0, 0, 0);
        }
        else if (direction == Direction.South)
        {
            transform.Rotate(0, 180, 0);
        }
        else if (direction == Direction.East)
        {
            transform.Rotate(0, 90, 0);
        }
        else if (direction == Direction.West)
        {
            transform.Rotate(0, 270, 0);
        }
    }

    virtual public void ApplyMaterials(Material primaryMaterial, Material accentMaterial) {
        
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
