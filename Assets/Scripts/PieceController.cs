using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{

    private Player playerType;

    public Direction direction;

    public void SetupObject(Player playerType, Direction direction)
    {
        this.playerType = playerType;
        this.direction = direction;

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
        Debug.Log("ApplyMaterials override karna bhool gaye kya?");
    }

    
    
    public Direction RotateRelativeToNorth(Direction direction) 
    {
        /*
            To detect laser hits, we can RE-ORIENT the laser's
            actual direction by imagining this piece to be facing
            NORTH.

            To do so, we apply the SAME rotation to the LASER's 
            DIRECTION which, if applied to this piece's direction,
            would make THIS PIECE face north.

            Applying rotations can be done using arithmetic mod 4.
        */
        return (Direction)(((int)direction - (int)this.direction + 4) % 4);
    }

    public Direction UnrotateRelativeToNorth(Direction direction) 
    {
        return (Direction)(((int)direction + (int)this.direction) % 4);
    }

    virtual public Direction GetHitByLaser(Direction laserDirection)
    {
        Debug.Log("GetHitByLaser override karna bhool gaye kya?");
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
