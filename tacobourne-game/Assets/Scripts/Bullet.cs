using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 50;

    public GameObject impactEffect;


    // When our bullet is created we will move
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // On hit destory bullet and apply damage to enemy 
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        Debug.Log(hitInfo.name);
        Destroy(gameObject);

        var explosion = Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(explosion, .5f);

       

        // Get all entities with EnemyAI script attached
        EnemyAI enemy = hitInfo.GetComponent<EnemyAI>();

        if(enemy != null)
        {
            enemy.TakeDamage(damage);
            Debug.Log(enemy.name + " has " + enemy.health + " health");
        }

    }

}
