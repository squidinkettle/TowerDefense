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
    Transform closestEnemy;



    Enemy[] enemiesInMap;
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
        enemiesInMap = FindObjectsOfType<Enemy>();

        if(enemiesInMap.Length>0)
            closestEnemy = enemiesInMap[0].transform;

        foreach (Enemy enemy in enemiesInMap)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, enemy);
        }
        LookAtEnemy(closestEnemy);

    

    }

    private Transform GetClosestEnemy(Transform closeEnemy, Enemy enemy)
    {
        var distanceToNewEnemy = Vector3.Distance(gameObject.transform.position, enemy.transform.position);
        var distanceToCurrentEnemy = Vector3.Distance(gameObject.transform.position, closeEnemy.position);

        if (distanceToNewEnemy < distanceToCurrentEnemy)
        {
            return enemy.transform;
        }
        else
        {
            return closeEnemy;
        }

    }

    private void OnMouseOver()
    {
        print(gameObject.name);
    }

    void LookAtEnemy(Transform enemy)
    {
        var particles = bullets.GetComponent<ParticleSystem>().emission;

        if (enemy != null)
        {
            var distanceToEnemy = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
            if (distanceToEnemy < range)
            {
                SetupParticleEmission(enemy, particles);

            }
            else
            {
                particles.enabled = false;
            }

        }
        else
        {
            particles.enabled = false;
        }

    }

    private void SetupParticleEmission(Transform enemy, ParticleSystem.EmissionModule particles)
    {
        particles.enabled = true;
        particles.rateOverTime = rateOfFire;
        float yOffset = 5;

        Vector3 enemyPos = new Vector3(

        enemy.transform.position.x,
        enemy.transform.position.y + yOffset,
        enemy.transform.position.z);

        objectToPan.transform.LookAt(enemyPos);
    }

  

}
