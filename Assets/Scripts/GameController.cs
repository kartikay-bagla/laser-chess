using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    public GameObject squarePrefab;
    public GameObject kingPrefab;
    public GameObject switchPrefab;
    public GameObject deflectorPrefab;
    public GameObject defenderPrefab;
    public GameObject laserPrefab;

    private int gridSize = 8;
    private GameObject[,] grid;

    // Start is called before the first frame update
    void Start()
    {
        BuildGrid();

        GameObject p1_king = Instantiate(kingPrefab, new Vector3(0, 0.2f, 0), Quaternion.identity);
        p1_king.GetComponent<KingController>().SetupObject(1);

        GameObject p2_king = Instantiate(kingPrefab, new Vector3(2, 0.2f, 0), Quaternion.identity);
        p2_king.GetComponent<KingController>().SetupObject(2);

        GameObject p1_switch = Instantiate(switchPrefab, new Vector3(4, 0.2f, 0), Quaternion.identity);
        p1_switch.GetComponent<SwitchController>().SetupObject(1);

        GameObject p2_switch = Instantiate(switchPrefab, new Vector3(6, 0.2f, 0), Quaternion.identity);
        p2_switch.GetComponent<SwitchController>().SetupObject(2);

        GameObject p1_deflector = Instantiate(deflectorPrefab, new Vector3(8, 0.2f, 0), Quaternion.identity);
        p1_deflector.GetComponent<DeflectorController>().SetupObject(1);

        GameObject p2_deflector = Instantiate(deflectorPrefab, new Vector3(10, 0.2f, 0), Quaternion.identity);
        p2_deflector.GetComponent<DeflectorController>().SetupObject(2);

        GameObject p1_defender = Instantiate(defenderPrefab, new Vector3(12, 0.2f, 0), Quaternion.identity);
        p1_defender.GetComponent<DefenderController>().SetupObject(1);

        GameObject p2_defender = Instantiate(defenderPrefab, new Vector3(14, 0.2f, 0), Quaternion.identity);
        p2_defender.GetComponent<DefenderController>().SetupObject(2);

        GameObject p1_laser = Instantiate(laserPrefab, new Vector3(0, 0.2f, 2f), Quaternion.identity);
        p1_laser.GetComponent<LaserController>().SetupObject(1);

        GameObject p2_laser = Instantiate(laserPrefab, new Vector3(2f, 0.2f, 2f), Quaternion.identity);
        p2_laser.GetComponent<LaserController>().SetupObject(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BuildGrid()
    {
        grid = new GameObject[gridSize, gridSize];
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                grid[i, j] = Instantiate(squarePrefab, new Vector3(2*i, 0, 2*j), Quaternion.identity);
                GameObject child = grid[i, j].transform.GetChild(0).gameObject;
            }
        }
    }
}
