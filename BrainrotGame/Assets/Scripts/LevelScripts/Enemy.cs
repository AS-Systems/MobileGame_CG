using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //Script for handling enemies

    public float maximumHealth;     //Max health an enemy can have
    public float health;            //Actual health of the enemy
    public float damage;            //Damage the enemy does to the player
    public float damageFrequency;   //How often it hurts the player

    public Pigeon pigeon;           //Player
    public Slider healthBar;        //Health bar above enemy
    public Text txtMoney;           //Label of money in the UI
    
    private float timeSinceLastDamage;  //Counting time since last damage was dealt

    void Start()
    {
        //Set health bar and find objects in the scene
        health = maximumHealth;
        healthBar.maxValue = maximumHealth;
        healthBar.value = health;
        pigeon = GameObject.Find("Pigeon").GetComponent<Pigeon>();
        txtMoney = GameObject.Find("txtMoney").GetComponent<Text>();
    }

    void Update()
    {
        if(health <= 0)
        {
            die();
        }

    }

    //Deal damage only if pigeon isn't immune
    void dealDamage()
    {
        if (pigeon.immunity == true)
        {
            return;
        }
        pigeon.health -= damage;
    }

    //Lower health after being struck with bullet. This function is called by bullet.
    public void takeDamage(float damage)
    {
        health -= damage;
        updateHealthBar(health);
    }

    //Give pigeon money by setting label and PlayerPrefs, destroy enemy
    void die()
    {
        pigeon.money++;
        PlayerPrefs.SetInt("moneyLevel", pigeon.money);
        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 1);
        txtMoney.text = pigeon.money.ToString();
        Destroy(gameObject);

    }   
    
    //Show change of health on healthbar
    void updateHealthBar(float health)
    {
        healthBar.value = health;
    }

    //Deal damage to the player if enemy is in it's collission
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
