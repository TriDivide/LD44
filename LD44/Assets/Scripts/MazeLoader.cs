using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MazeLoader : MonoBehaviour {
    [SerializeField]
    private int mazeRows, mazeColumns;
    [SerializeField]
    private GameObject wall, collectable, hostile;
    [SerializeField]
    private float size = 2f;

    [SerializeField]
    private NavMeshSurface surface;

    [SerializeField]
    private int collectableNumber = 5;
    private int enemyNumber = 6;

    private MazeCell[,] mazeCells;

    // Use this for initialization
    void Start() {
        InitializeMaze();

        MazeAlgorithm ma = new HuntAndKillMazeAlgorithm(mazeCells);
        ma.CreateMaze();

    //    surface.BuildNavMesh();
        
    }

    // Update is called once per frame
    void Update() {
    }

    private void InitializeMaze() {

        mazeCells = new MazeCell[mazeRows, mazeColumns];

        for (int r = 0; r < mazeRows; r++) {
            for (int c = 0; c < mazeColumns; c++) {
                mazeCells[r, c] = new MazeCell();

                // For now, use the same wall object for the floor!
                mazeCells[r, c].floor = Instantiate(wall, new Vector3(r * size, -(size / 2f), c * size), Quaternion.identity) as GameObject;
                mazeCells[r, c].floor.name = "Floor " + r + "," + c;
                mazeCells[r, c].floor.transform.Rotate(Vector3.right, 90f);

                // add a collectable at position.
                int random = Random.Range(1, 10);
                if (random == collectableNumber) {
                    mazeCells[r, c].item = Instantiate(collectable, new Vector3(r * size, -(size / 2f) + 1, c * size), Quaternion.identity) as GameObject;
                    mazeCells[r, c].item.name = "Item " + r + ", " + c;
                    mazeCells[r, c].item.transform.Rotate(Vector3.right, 90f);
                }


                // Adds an enemy at position
                if (random == enemyNumber) {
                    
                //    mazeCells[r, c].hostile = Instantiate(hostile, new Vector3(r * size, 3, c * size), hostile.transform.rotation) as GameObject;
                  //  GameObject baddy = mazeCells[r, c].hostile;
                    //baddy.name = "hostile " + r + ", " + c;
                    //baddy.transform.Rotate(Vector3.right, 90f);
                }

                if (c == 0) {
                    mazeCells[r, c].westWall = Instantiate(wall, new Vector3(r * size, 0, (c * size) - (size / 2f)), Quaternion.identity) as GameObject;
                    mazeCells[r, c].westWall.name = "West Wall " + r + "," + c;

                }

                mazeCells[r, c].eastWall = Instantiate(wall, new Vector3(r * size, 0, (c * size) + (size / 2f)), Quaternion.identity) as GameObject;
                mazeCells[r, c].eastWall.name = "East Wall " + r + "," + c;


                if (r == 0) {
                    mazeCells[r, c].northWall = Instantiate(wall, new Vector3((r * size) - (size / 2f), 0, c * size), Quaternion.identity) as GameObject;
                    mazeCells[r, c].northWall.name = "North Wall " + r + "," + c;
                    mazeCells[r, c].northWall.transform.Rotate(Vector3.up * 90f);

                }

                mazeCells[r, c].southWall = Instantiate(wall, new Vector3((r * size) + (size / 2f), 0, c * size), Quaternion.identity) as GameObject;
                mazeCells[r, c].southWall.name = "South Wall " + r + "," + c;
                mazeCells[r, c].southWall.transform.Rotate(Vector3.up * 90f);

            }
        }
    }
}
