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
        if (health <= 0)
        {
            StartDeath();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        //print("hit");
        SetHealth(5);
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
