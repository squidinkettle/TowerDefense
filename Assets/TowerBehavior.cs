using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    PathFinder pathfinder;
    Waypoint waypoint;
    [SerializeField]float range;
    [SerializeField] float rateOfFire;
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

    private void ShootClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy enemy in enemies)
        {
            var distanceToTower = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
            if (distanceToTower < range)
            {
                print("Pew pew");
            }



        }
    }
    IEnumerator ShootEnemy(float cooldown)
    {

        yield return new WaitForSeconds(cooldown);
    }

}
