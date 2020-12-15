using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    PathFinder pathfinder;
    List<Waypoint> path=new List<Waypoint>();

    [SerializeField] Vector2Int startPos;
    [SerializeField] Vector2Int endPos;


    // Start is called before the first frame update
    void Start()
    {
        StartPath();



        StartCoroutine(PrintAllWayPoints());
    }


    private void StartPath()
    {
        pathfinder = FindObjectOfType<PathFinder>();

        pathfinder.setStartPath(startPos);
        pathfinder.setEndPath(endPos);
        pathfinder.SetQueueStart(startPos);
        pathfinder.FindPath();


        var startingPosition = pathfinder.start;
        var pathfindingGrid = pathfinder.grid;
        var shortestPath = pathfinder.shortestPath;
        //path.Add(pathfindingGrid[startingPosition]);
        foreach (Waypoint point in shortestPath)
        {
            path.Add(point);
        }

        path.Reverse();
    }

    IEnumerator PrintAllWayPoints()
    {
  
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }

    }


    public void SetStartEndPosition(Vector2Int startP, Vector2Int endP)
    {
        startPos = startP;
        endPos = endP;
    }
 

    // Update is called once per frame
    void Update()
    {


    }
}
