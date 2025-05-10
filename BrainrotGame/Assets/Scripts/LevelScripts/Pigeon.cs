using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pigeon : MonoBehaviour
{
    public AudioSource audioSource1;    //Sound of pigeon1
    public AudioSource audioSource2;    //Sound of pigeon2
    public GameObject[] weaponsModels;  //Legacy solution
    public Slider healthBar;            //Health bar on the UI

    public int money = 0;               //Money gained on level (Legacy?)
    public float maxHealth = 100;       //Maximum health
    public float health;                //Actual health
    public float[] weaponsDamages;      //Legacy solution
    public float[] weaponsBulletSpeeds; //Legacy solution
    public float[] weaponsReloadSpeeds; //Legacy solution
    public int weaponIndex;             //Actually equipped weapon (legacy?)
    public float damage;                //Damage of the equipped weapon (legacy?)
    public float bulletSpeed;           //Speed of the equipped weapon (legacy?)
    public bool immunity;               //True = pigeon's health can't lower

    public float immunityTime = 10f;    //Time of immunity after picking up powerup
    public float immunityTimePassed = 0;//Time passed since immunity powerup was picked up
    public float minTimeBetweenSounds;  //Minimum time between sounds
    public float timeOfSounds;          //Time since last sound was played

    void Start()
    {
        //Set up all variables and objects
        health = maxHealth;
        healthBar= GameObject.Find("PigeonHealthBar").GetComponent<Slider>();
        healthBar.maxValue = health;
        damage = weaponsDamages[weaponIndex]; //Legacy
    }

    void Update()
    {
        //Count time of immunity if it's active
        if(immunity == true)
        {
            
            immunityTimePassed += Time.deltaTime;

        }
        //Turn off immunity if time passed
        if (immunityTimePassed >= immunityTime)
        {
            immunity = false;
            immunityTimePassed = 0;
        }
        //Update health bar
        healthBar.value = health;
        //Check if pigeon is out of health
        if(health <= 0)
        {
            Died();
        }
        //After set time choose randomly which sound to play
        if(timeOfSounds > minTimeBetweenSounds)
        {
            bool choiceOfSound;
            choiceOfSound = Random.value > 0.5f;
            if (choiceOfSound)
            {
               // audioSource1.Play();  Sees sound as null?
            }
            else
            {
               // audioSource2.Play();
            }
            timeOfSounds = 0;
        }
        timeOfSounds += Time.deltaTime;
    }
    //Load EndView Scene after pigeon runs out of health
    void Died()
    {
        SceneManager.LoadScene("EndViewDeath");
    }
}
