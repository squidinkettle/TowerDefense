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
        pathfinder = FindObjectOfType<PathFinder>();

       
       

    }

   

    // Update is called once per frame
    void Update()
    {
        ShootClosestEnemy();

    }

    void ShootClosestEnemy()
    {
        var particles = bullets.GetComponent<ParticleSystem>().emission;
        enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy enemy in enemies)
        {
            var distanceToTower = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
            if (distanceToTower < range)
            {

                particles.enabled = true;



                LookAtEnemy();
            }
            else
            {
                particles.enabled = false;
            }





        }

        if (enemies.Length==0)
        {
            particles.enabled = false;
        }

    }



    void LookAtEnemy()
    {
        foreach(Enemy enemy in enemies)
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

}
