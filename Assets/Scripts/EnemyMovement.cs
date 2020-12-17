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
    [SerializeField] float enemySpeed=10f;
    [SerializeField] ParticleSystem damageBase;
    [SerializeField] AudioClip reachedGoalFX;

    PlayerBase playerBase;


    // Start is called before the first frame update
    void Start()
    {
        playerBase = FindObjectOfType<PlayerBase>();
        var enemyBase = FindObjectOfType<EnemyBase>();


        StartPath();

        float time = 0.5f;

        StartCoroutine(PrintAllWayPoints(time));
    }
    public void DestroyWhenReachesEnd()
    {
        Vector3 newPos = new Vector3(
        transform.position.x,
        transform.position.y+10,
        transform.position.z
        );

  
        AudioSource.PlayClipAtPoint(reachedGoalFX, Camera.main.transform.position);
        var newExplosion=Instantiate(damageBase, newPos,Quaternion.identity);
        newExplosion.Play();
        Destroy(newExplosion.gameObject, newExplosion.main.duration);
        playerBase.SetHealth(10);
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
            var currentPos = transform.position;
            var speed = enemySpeed;
            while (currentPos!=waypoint.transform.position)
            {
                var delta = Time.deltaTime * speed;
                transform.position = Vector3.MoveTowards(transform.position, waypoint.transform.position, delta);
                currentPos = transform.position;
            
                yield return null;
            }

            //transform.position = waypoint.transform.position;
            var enemyHasReachedDestination = (transform.position == (pathfinder.grid[endPos].transform.position));
            if (enemyHasReachedDestination)
            {

                DestroyWhenReachesEnd();

            }
        }
        DestroyWhenReachesEnd();

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
