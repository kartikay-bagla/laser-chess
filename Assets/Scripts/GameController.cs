using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player
{
    Open,       // O
    Red,        // R
    White       // W
}

public enum Name
{
    King,       // K
    Switch,     // S
    Deflector,  // T
    Defender,   // D
    Laser       // L
}

public enum Direction
{
    North,      // N
    East,       // E
    South,      // S
    West,       // W
    None        // X
}

public class GameController : MonoBehaviour
{

    public GameObject squarePrefab;
    public GameObject kingPrefab;
    public GameObject switchPrefab;
    public GameObject deflectorPrefab;
    public GameObject defenderPrefab;
    public GameObject laserPrefab;

    public Material whitePrimaryMaterial;
    public Material redPrimaryMaterial;

    private int rows = 8;
    private int columns = 10;
    private GameObject[,] grid;
    private GameObject[,] pieceGrid;

    private Player[,] blockedAreas;

    // Start is called before the first frame update
    void Start()
    {
        BuildGrid();

        string gridString = ""
            + "LRS O O O DRS KRN DRS TRE O O\n"
            + "O O TRS O O O O O O O\n"
            + "O O O TWW O O O O O O\n"
            + "TRN O TWS O SRS SRE O TRE O TWW\n"
            + "TRE O TWW O SWE SWS O TRN O TWS\n"
            + "O O O O O O TRE O O O\n"
            + "O O O O O O O TWN O O\n"
            + "O O TWW DWN KWN DWN O O O LWN\n";

        BuildPiecesFromString(gridString);

        // pieceGrid[0, 0].GetComponent<LaserController>().EmitLaser();
        CalculateLaser(Player.Red);
    }

    void CalculateLaser(Player player) {
        GameObject laserObj = player == Player.Red ? pieceGrid[0, 0] : pieceGrid[7, 9];
        LaserController laser = laserObj.GetComponent<LaserController>();
        (int rowDelta, int columnDelta) = GetDirectionDeltas(laser.direction);

        int row = Mathf.FloorToInt(laserObj.transform.position.x / 2);
        int col = Mathf.FloorToInt(laserObj.transform.position.z / 2);

        int counter = 100;
        while (counter > 0) {

            counter--;

            row += rowDelta;
            col += columnDelta;

            if (row < 0 || row >= rows || col < 0 || col >= columns) {
                break;
            }

            if (pieceGrid[row, col] != null) {
                Direction newDirection = pieceGrid[row, col].GetComponent<PieceController>().GetHitByLaser(rowDelta, columnDelta);
                Debug.Log("Hit " + pieceGrid[row, col].name + " at " + row + ", " + col);
                Debug.Log("New direction: " + newDirection);
                
                if (newDirection == Direction.None) {
                    break;
                }
                
                (rowDelta, columnDelta) = GetDirectionDeltas(newDirection);
                // break;
            }
        }
    }

    (int, int) GetDirectionDeltas(Direction dir) {
        int rowDelta = 0, columnDelta = 0;
        if (dir == Direction.North) {
            rowDelta = -1;
        } else if (dir == Direction.East) {
            columnDelta = 1;
        } else if (dir == Direction.South) {
            rowDelta = 1;
        } else if (dir == Direction.West) {
            columnDelta = -1;
        }
        return (rowDelta, columnDelta);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BuildGrid()
    {
        grid = new GameObject[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                grid[i, j] = Instantiate(squarePrefab, new Vector3(2 * i, 0, 2 * j), Quaternion.identity);
                GameObject child = grid[i, j].transform.GetChild(0).gameObject;
            }
        }
        BuildBlockedAreas();
    }

    void BuildBlockedAreas()
    {
        blockedAreas = new Player[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                blockedAreas[i, j] = Player.Open;
            }
        }

        // Red
        int[,] redBlocked = new int[9, 2] {
            {0, 1},
            {7, 1},
            {0, 9},
            {1, 9},
            {2, 9},
            {3, 9},
            {4, 9},
            {5, 9},
            {6, 9}
        };

        for (int i = 0; i < redBlocked.GetLength(0); i++)
        {
            blockedAreas[redBlocked[i, 0], redBlocked[i, 1]] = Player.Red;
            GameObject gridSquare = grid[redBlocked[i, 0], redBlocked[i, 1]].transform.GetChild(0).gameObject;
            gridSquare.GetComponent<MeshRenderer>().material = whitePrimaryMaterial;
        }

        // White
        int[,] whiteBlocked = new int[9, 2] {
            {0, 8},
            {7, 8},
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0},
            {7, 0}
        };

        for (int i = 0; i < whiteBlocked.GetLength(0); i++)
        {
            blockedAreas[whiteBlocked[i, 0], whiteBlocked[i, 1]] = Player.White;
            GameObject gridSquare = grid[whiteBlocked[i, 0], whiteBlocked[i, 1]].transform.GetChild(0).gameObject;
            gridSquare.GetComponent<MeshRenderer>().material = redPrimaryMaterial;
        }

    }

    void BuildPiecesFromString(string gridString)
    {
        string[] rowStrings = gridString.Split('\n');
        pieceGrid = new GameObject[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            string[] columnStrings = rowStrings[i].Split(' ');
            for (int j = 0; j < columns; j++)
            {
                pieceGrid[i, j] = GetPieceFromString(columnStrings[j], i, j);
            }
        }
    }

    GameObject GetPieceFromString(string pieceString, int row, int col)
    {

        if (pieceString[0] == 'O')
        {
            return null;
        }

        GameObject piece = pieceString[0] == 'K' ? kingPrefab : pieceString[0] == 'S' ? switchPrefab : pieceString[0] == 'T' ? deflectorPrefab : pieceString[0] == 'L' ? laserPrefab : defenderPrefab;
        Player playerType = pieceString[1] == 'R' ? Player.Red : Player.White;
        Direction direction = pieceString[2] == 'N' ? Direction.North : pieceString[2] == 'E' ? Direction.East : pieceString[2] == 'S' ? Direction.South : Direction.West;

        GameObject pieceObject = Instantiate(piece, new Vector3(2 * row, 0, 2 * col), Quaternion.identity);
        pieceObject.GetComponent<PieceController>().SetupObject(playerType, direction);

        return pieceObject;
    }

}
