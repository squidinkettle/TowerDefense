using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    public Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    public Vector2Int start, end=new Vector2Int();

    Queue<Vector2Int> queueCoordinate = new Queue<Vector2Int>();

    public List<Waypoint> shortestPath = new List<Waypoint>();

    private void Awake()
    {
  
        LoadBlocks();

    }

    // Start is called before the first frame update
    void Start()
    {

    
   
   
    }
    public void SetQueueStart(Vector2Int startP)
    {
        queueCoordinate.Enqueue(startP);
    }


    // Update is called once per frame
    void Update()
    {
       
    }
    public void setStartPath(Vector2Int startPath)
    {
        start = startPath;
    }
    public void setEndPath(Vector2Int endPath)
    {
        end = endPath;
    }

    void LoadBlocks() {

        var waypoints = FindObjectsOfType<Waypoint>();
        
        foreach(Waypoint waypoint in waypoints)
        {
            if (waypoint.tag != "Obstacle")
            {
                FillGridInformation(waypoint);
            }

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
    public void FindPath()
    {
   
        while (queueCoordinate.Count>0)
        {

            var newPos=queueCoordinate.Dequeue();

            if (newPos == end) 
            {
                FindAdjacentGrid(newPos);
                queueCoordinate.Clear();
                FindShortestPath();
                break; 
            }

            FindAdjacentGrid(newPos);

        }
        foreach(var waypoint in grid.Values)
        {
            waypoint.isSearched = false;
        }



    }

    public void FindShortestPath()
    {
        var currentPoint = grid[end];
        while (currentPoint != grid[start])
        {
            shortestPath.Add(currentPoint);
            currentPoint = currentPoint.exploredFrom;
        }

        foreach (Waypoint point in shortestPath)
        {
            point.SetTopColor(Color.cyan);
        }

    }

    void FindAdjacentGrid(Vector2Int pos)
    {
        Vector2Int[] adjacentPositions = {
         Vector2Int.up,
         Vector2Int.down,  
         Vector2Int.right,
         Vector2Int.left
         };
          
        foreach (Vector2Int adjacent in adjacentPositions)
        {
            var sumPosAndAdjecent = pos + adjacent;


            if (grid.ContainsKey(sumPosAndAdjecent))
            {
                var nextWaypoint = grid[sumPosAndAdjecent];
                var currentWaypoint = grid[pos];


                nextWaypoint.SetTopColor(Color.blue);



                if (!queueCoordinate.Contains(sumPosAndAdjecent) && nextWaypoint.isSearched==false)
                {

                    nextWaypoint.exploredFrom= currentWaypoint;
                   
                    nextWaypoint.isSearched = true;
                  
                    queueCoordinate.Enqueue(sumPosAndAdjecent);
                }

            }


        }


    }
}
