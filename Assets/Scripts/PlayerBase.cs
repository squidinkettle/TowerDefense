using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{

    [SerializeField] int maxHealth;
    [SerializeField] Text score;
    [SerializeField] Text healthText;
    int health;
    int totalScore;

    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        score.text = "0";
        health = maxHealth;
        healthText.text = maxHealth.ToString();
    }
    public void SetScore(int addScore)
    {
        totalScore += addScore;
        score.text = "Score: "+totalScore.ToString();
    }
    public void SetHealth(int num)
    {

        health -= num;
        healthText.text = health.ToString();
    }
    public int GetHealth()
    {
        return health;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
