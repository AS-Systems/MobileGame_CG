using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float maximumHealth;
    public float health;
    public float damage;
    public float damageFrequency;

    public Pigeon pigeon;
    public Slider healthBar;
    
    public float timeSinceLastDamage;

    // Start is called before the first frame update
    void Start()
    {
        health = maximumHealth;
        healthBar.maxValue = maximumHealth;
        healthBar.value = health;
        pigeon = GameObject.Find("Pigeon").GetComponent<Pigeon>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            die();
        }

    }

    void dealDamage()
    {
        pigeon.health -= damage;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        updateHealthBar(health);
    }

    void die()
    {
        Destroy(gameObject);
    }   
    
    void updateHealthBar(float health)
    {
        healthBar.value = health;
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == 10)
        {
            timeSinceLastDamage += Time.deltaTime;
            if(timeSinceLastDamage >= damageFrequency)
            {
                dealDamage();
                timeSinceLastDamage = 0;
            }
        }
    }
}
