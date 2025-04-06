using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pigeon : MonoBehaviour
{
    public GameObject[] weaponsModels;
    public Slider healthBar;

    public int money = 0;
    public float maxHealth = 100;
    public float health;
    public float[] weaponsDamages;
    public int weaponIndex;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar= GameObject.Find("PigeonHealthBar").GetComponent<Slider>();
        healthBar.maxValue = health;
    }

    // Update is called once per frame
    void Update()
    {

        healthBar.value = health;
    }
}
