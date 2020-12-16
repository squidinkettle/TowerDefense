using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int maxHealth;
    [SerializeField] ParticleSystem particlesDeath;
    [SerializeField] ParticleSystem particleHit;

    [SerializeField] Transform fxParent;
    int health;



    // Start is called before the first frame update
    void Start()
    {
        fxParent = FindObjectOfType<TrashHandler>().transform;
        health = maxHealth;
    }

    void SetHealth(int change)
    {
        health -= change;
        Vector3 enemyPosition = GetInstantiatePosition(12f);
        var particleH=Instantiate(particleHit, enemyPosition, Quaternion.identity);
        particleH.transform.parent = fxParent;
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
        Vector3 enemyPos = GetInstantiatePosition(10f);
        var fx=Instantiate(particlesDeath, enemyPos, Quaternion.identity);
        fx.Play();
        Destroy(fx.gameObject, fx.main.duration);
        fx.transform.parent = fxParent;
        Destroy(gameObject, 2f);
    }

    private Vector3 GetInstantiatePosition(float offset)
    {
        var yOffset = offset;
        Vector3 enemyPos = new Vector3(
        gameObject.transform.position.x,
        gameObject.transform.position.y + yOffset,
       gameObject.transform.position.z);
        return enemyPos;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   


}
