using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerBase playerBase;
    [SerializeField] EnemyBase enemyBase;

    int playerHealth;
    Enemy[] totalEnemies;
    int enemyWaves;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = playerBase.GetHealth();
        if (playerHealth <= 0)
        {
            print("Game Over");
        }

        enemyWaves = enemyBase.GetWaves();

        if (enemyWaves <= 0)
        {
            totalEnemies = FindObjectsOfType<Enemy>();
            if (totalEnemies.Length <= 0) {

                print("You've won!");
               }
        }

    }
}
