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
    [SerializeField] Transform enemyParent;
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


        for(int x = 0; x < numberOfStartingCoordinates; x++)
        {
            GenerateEnemies(startSpawnPosition[x], endPosition[x]);
        }





    }


    void GenerateEnemies(Vector2Int start,Vector2Int end )
    {
        PathFinder pathfind = FindObjectOfType<PathFinder>();
     
        GameObject newEnemy=Instantiate (enemy, transform.position,Quaternion.identity);
        newEnemy.transform.parent = enemyParent;
        newEnemy.GetComponent<EnemyMovement>().SetStartEndPosition(start,end);

    }

    public int GetWaves()
    {
        return numberOfWaves;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
