using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    PathFinder pathfinder;
    Waypoint waypoint;
    [SerializeField] float range;
    [SerializeField] float rateOfFire;
    [SerializeField] GameObject objectToPan;
    [SerializeField] GameObject bullets;
    Vector3 defaultPos;



    Enemy[] enemies;
    // Start is called before the first frame update
    void Start()
    {

        waypoint = GetComponent<Waypoint>();

       
       

    }

   

    // Update is called once per frame
    void Update()
    {
        IterateEnemies();

    }

    void IterateEnemies()
    {
        var particles = bullets.GetComponent<ParticleSystem>().emission;
        enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies)
            particles.enabled = ShootClosestEnemy(particles, enemy);

        if (enemies.Length == 0)
        {
            print(enemies.Length);
            particles.enabled = false;
        }

    }

    private bool ShootClosestEnemy(ParticleSystem.EmissionModule particles, Enemy enemy)
    {
        var distanceToTower = Vector3.Distance(enemy.transform.position, gameObject.transform.position);

       if (distanceToTower < range)
        {
      
            LookAtEnemy(enemy);
            return  true;

        }
        else
        {
            return false;
        }


    }



    void LookAtEnemy(Enemy enemy)
    {
       
        var distanceToEnemy= Vector3.Distance(enemy.transform.position, gameObject.transform.position);
        if(distanceToEnemy < range)
        {
            float yOffset = 5;

            Vector3 enemyPos = new Vector3(
            enemy.transform.position.x,
            enemy.transform.position.y + yOffset,
            enemy.transform.position.z);

            objectToPan.transform.LookAt(enemyPos);
      
        }
        


    }

}
