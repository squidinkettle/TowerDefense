using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] TowerBehavior towerPrefab;
    [SerializeField] int queueSize;
    Queue<TowerBehavior> towers;
    // Start is called before the first frame update
    void Start()
    {
        CircularBuffer(queueSize);
    }

    public void InstantiateOnCube(Vector3 cubePos)
    {
        TowerBehavior newTower=Instantiate(towerPrefab, cubePos, Quaternion.identity);
        Add(newTower);
    }

    void CircularBuffer(int size)
    {
        towers = new Queue<TowerBehavior>(size);

    }
    void Add(TowerBehavior tower)
    {
        int numTowers = towers.Count;
        if (numTowers >= queueSize)
        {
            print("Enqueued and dequeued");
            towers.Enqueue(tower);
            towers.Dequeue();
        }
        else
        {
            print("enqueued only");
            towers.Enqueue(tower);
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
