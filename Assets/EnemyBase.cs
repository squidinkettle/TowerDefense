using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] Vector2Int[] startSpawnPosition;
    [SerializeField] Vector2Int[] endPosition;
    [SerializeField] GameObject enemy;
    [SerializeField] int numberOfWaves;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void InitializeSpawnAreas()
    {
        var numberOfStartingCoordinates = startSpawnPosition.Length;
        switch (numberOfStartingCoordinates)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;

        }



    }

    void GenerateEnemies(Vector2Int start,Vector2Int end )
    {
        GameObject newEnemy=Instantiate (enemy, transform.position,Quaternion.identity);

        newEnemy.GetComponent<EnemyMovement>().SetStartEndPosition(start,end);

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
