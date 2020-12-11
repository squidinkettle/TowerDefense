using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{


    [SerializeField] List<Waypoint> path;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine( PrintAllWayPoints());
    }

    IEnumerator PrintAllWayPoints()
    {
        print("Starting Patrol...");
        foreach (Waypoint waypoint in path)
        {
            print("Visiting"+waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        print("...Ending Patrol");
    }

    // Update is called once per frame
    void Update()
    {


    }
}
