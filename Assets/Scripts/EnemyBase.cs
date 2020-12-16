using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] Vector2Int[] startSpawnPosition;
    [SerializeField] Vector2Int[] endPosition;
    [SerializeField] GameObject enemy;
    [SerializeField] int numberOfWaves;
    [SerializeField] float timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

  

    IEnumerator SpawnEnemies()
    {
        while (numberOfWaves > 0)
        {
            SortSpawnAreas();
            numberOfWaves--;

            yield return new WaitForSeconds(timer);
        }



    }
    public Vector2Int GetStartPosition(Vector2Int start, int x)
    {
        return startSpawnPosition[x];
    }
    public Vector2Int GetEndPosition(Vector2Int end, int x)
    {
        return endPosition[x];
    }

    void SortSpawnAreas()
    {
        var numberOfStartingCoordinates = startSpawnPosition.Length;

        switch (numberOfStartingCoordinates)
        {
            case 1:
                GenerateEnemies(startSpawnPosition[0], endPosition[0]);
                break;
            case 2:
                {
       
                    GenerateEnemies(startSpawnPosition[0], endPosition[0]);
   
                    GenerateEnemies(startSpawnPosition[1], endPosition[1]);
                }

                break;
            case 3:
                break;
            default:
                break;

        }



    }


    void GenerateEnemies(Vector2Int start,Vector2Int end )
    {
        PathFinder pathfind = FindObjectOfType<PathFinder>();
     
        GameObject newEnemy=Instantiate (enemy, transform.position,Quaternion.identity);

        newEnemy.GetComponent<EnemyMovement>().SetStartEndPosition(start,end);

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
