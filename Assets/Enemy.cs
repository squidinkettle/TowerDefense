using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int maxHealth;
    int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    void SetHealth(int change)
    {
        health -= change;
    }

    void StartDeath()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
