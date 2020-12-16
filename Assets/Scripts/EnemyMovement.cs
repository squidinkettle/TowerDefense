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
        var enemyBase = FindObjectOfType<EnemyBase>();


        StartPath();

        float time = 0.5f;

        StartCoroutine(PrintAllWayPoints(time));
    }
    void DestroyWhenReachesEnd()
    {
        Destroy(gameObject);
    }

    private void StartPath()
    {
        SetupPathfinder();

        GetPath();
    }

    private void GetPath()
    {
        var startingPosition = pathfinder.start;
        var pathfindingGrid = pathfinder.grid;
        var shortestPath = pathfinder.shortestPath;

        foreach (Waypoint point in shortestPath)
        {
            path.Add(point);
        }
        path.Add(pathfindingGrid[startingPosition]);

        path.Reverse();
    }

    private void SetupPathfinder()
    {
        pathfinder = FindObjectOfType<PathFinder>();

        pathfinder.setStartPath(startPos);
        pathfinder.setEndPath(endPos);


        pathfinder.SetQueueStart(startPos);
        pathfinder.FindPath();
    }

    IEnumerator PrintAllWayPoints(float time)
    {
  
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            var enemyHasReachedDestination = gameObject.transform.position == (pathfinder.grid[endPos].transform.position);
            if (enemyHasReachedDestination)
            {
                DestroyWhenReachesEnd();

            }
            yield return new WaitForSeconds(time);
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
