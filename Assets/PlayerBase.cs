using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{

    [SerializeField] int maxHealth;
    int health;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void SetHealth(int num)
    {
        health -= num;
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
