using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Vector2Int start, end=new Vector2Int();

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();   
    }

    // Update is called once per frame
    void Update()
    {
        FindAdjacentGrid();
    }

    void LoadBlocks() {

        var waypoints = FindObjectsOfType<Waypoint>();

        foreach(Waypoint waypoint in waypoints)
        {
            FillGridInformation(waypoint);

        }

    }

    private void FillGridInformation(Waypoint waypoint)
    {
        var gridPos = waypoint.GetGridPos();

        if (grid.ContainsKey(gridPos))
        {
            Debug.Log("Overlapping Block");
        }
        else
        {
           
            grid.Add(gridPos, waypoint);        //adds coordinates and waypoint object

       
            if (gridPos == start)
            {
                waypoint.SetTopColor( Color.black);
            }
            if(gridPos==end){
                waypoint.SetTopColor(Color.white);
            }

        }
    }


    void FindAdjacentGrid()
    {
        Vector2Int[] adjacentPositions = { new Vector2Int(0, 1)
    , new Vector2Int(0, -1),  new Vector2Int(1, 0),new Vector2Int(-1, 0)};
          
        foreach (Vector2Int adjacent in adjacentPositions)
        {
            var sumStartAndAdjacent = start + adjacent;
            print("Start + Adjacent " + sumStartAndAdjacent);
            if (grid.ContainsKey(sumStartAndAdjacent))
            {
                grid[sumStartAndAdjacent].SetTopColor(Color.blue);

            }


        }


    }
}
