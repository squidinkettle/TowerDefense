using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] TowerBehavior towerPrefab;
    [SerializeField] int queueSize;
    [SerializeField] Transform towerParent;


    //public Waypoint towerWaypoint;
    Queue<TowerBehavior> towers;
    // Start is called before the first frame update
    void Start()
    {
        CircularBuffer(queueSize);
    }

    public void InstantiateOnCube(Vector3 cubePos, Waypoint wp)
    {
        TowerBehavior newTower=Instantiate(towerPrefab, cubePos, Quaternion.identity);
        newTower.transform.parent = towerParent;
        newTower.waypoint = wp;
        towers.Enqueue(newTower);
       
    }

    void CircularBuffer(int size)
    {
        towers = new Queue<TowerBehavior>(size);

    }
    public void Add(Waypoint wp, Vector3 cubePos)
    {
        int numTowers = towers.Count;
        print(numTowers);
        if (numTowers >= queueSize)
        {
            print("Enqueued and dequeued");
            var oldTower = towers.Dequeue();
            oldTower.waypoint.isPath = false;
            oldTower.waypoint = wp;
            oldTower.transform.position = cubePos;

            towers.Enqueue(oldTower);

        }
        else
        {
            print("enqueued only");
            InstantiateOnCube(cubePos,wp);
        }

    }

    TowerBehavior Peek()
    {
        return towers.Peek();
    }
    TowerBehavior Read()
    {
        return towers.Dequeue();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
