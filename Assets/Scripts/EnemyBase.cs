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
    [SerializeField] AudioClip spawnEnemySFX;

    [SerializeField] int numberOfEnemies;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnEnemies());
    }



    IEnumerator SpawnEnemies()
    {
        int originalNumberEnemy = numberOfEnemies;
        int multiplier = 2;
   

    for (int x = 0; x < numberOfWaves; x++)
    {

        while (numberOfEnemies > 0)
        {
            GetComponent<AudioSource>().PlayOneShot(spawnEnemySFX);
            SortSpawnAreas();
            numberOfEnemies--;

            yield return new WaitForSeconds(timer);
        }

            while(FindObjectsOfType<Enemy>().Length > 0)
            {
                yield return null;
            }
            numberOfEnemies = originalNumberEnemy * multiplier;
            multiplier++;


        }
        numberOfWaves = -1;
          

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
