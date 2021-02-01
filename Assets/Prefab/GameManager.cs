using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerBase playerBase;
    [SerializeField] EnemyBase enemyBase;
    [SerializeField] GameObject winLose;
    Text winLoseText;

    int playerHealth;
    Enemy[] totalEnemies;
    int enemyWaves;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        winLoseText = winLose.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = playerBase.GetHealth();
        if (playerHealth <= 0)
        {
            Time.timeScale = 0;
            winLose.SetActive(true);
            winLoseText.text = "Game Over!";
            print("Game Over");
        }

        enemyWaves = enemyBase.GetWaves();

        if (enemyWaves <= 0)
        {
            totalEnemies = FindObjectsOfType<Enemy>();
            if (totalEnemies.Length <= 0) {
                Time.timeScale = 0;
                winLose.SetActive(true);
                winLoseText.text = "You've Won!";
                print("You've won!");
               }
        }

    }
}
