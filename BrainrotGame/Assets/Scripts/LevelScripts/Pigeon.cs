using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pigeon : MonoBehaviour
{
    public GameObject[] weaponsModels;
    public Slider healthBar;

    public int money = 0;
    public float maxHealth = 100;
    public float health;
    public float[] weaponsDamages;
    public float[] weaponsBulletSpeeds;
    public float[] weaponsReloadSpeeds;
    public int weaponIndex;
    public float damage;
    public float bulletSpeed;
    public bool immunity;

    public float immunityTime = 10f;
    public float immunityTimePassed = 0;



    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar= GameObject.Find("PigeonHealthBar").GetComponent<Slider>();
        healthBar.maxValue = health;
        damage = weaponsDamages[weaponIndex];
        bulletSpeed = weaponsBulletSpeeds[weaponIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if(immunity == true)
        {
        
            immunityTimePassed += Time.deltaTime;

        }
        if (immunityTimePassed >= immunityTime)
        {
            immunity = false;
            immunityTimePassed = 0;
        }

        healthBar.value = health;

        if(health <= 0)
        {
            Died();
        }
    }

    void Died()
    {
        SceneManager.LoadScene("EndViewDeath");
    }
}
