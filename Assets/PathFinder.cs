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
            grid.Add(gridPos, waypoint);

            int gSize = waypoint.GetGridSize();
            if (gridPos/gSize == start)
            {
                waypoint.SetTopColor(Color.black);
            }
            if(gridPos/gSize==end){
                waypoint.SetTopColor(Color.white);
            }

        }
    }
}
