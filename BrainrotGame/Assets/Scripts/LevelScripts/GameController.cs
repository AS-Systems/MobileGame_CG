using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Script for handling the infinite mode gameplay
    //Here enemies, weapons and pickups must spawn randomly but in a way the game is possible to pass

    public GameObject[] enemiesPrefabs;     //Array of enemies possible to spawn
    public GameObject[] weaponsPrefabs;     //Array of weapons possible to spawn
    public GameObject[] pickupsPrefabs;     //Array of pickups possible to spawn
    public GameObject spawnLeft;            //Left Empty spawn point
    public GameObject spawnRight;           //Right Empty spawn point

    private int[] unlockedWeapons;          //Weapons bought in store

    public float[] chanceOfEnemyChoice;     //Array showing with what chance each enemy may spawn (legacy solution)
    public float chanceOfWeaponSpawning;    //Chance of spawning a weapon in range of 0f-1f
    public float minTimeBetweenWeaponSpawns;//Minimum time between weapon spawns
    public float delayBetweenTryingToSpawnWeapon;//Delay between trying a chance to spawn weapon
    public float chanceOfPickupSpawning;    //Chance a pickup will be spawned

    public float minTimeBetweenEnemySpawns; //Minimum time between enemy spawns
    public float minTimeBetweenPickupsSpawns;//Minimum time between pickup spawns
    public float delayBetweenTryingToSpawnEnemy;//Delay between trying a chance to spawn enemy
    public float delayBetweenTryingToSpawnPickup;//Delay between trying a chance to spawn pickup

    private float timeSinceTryingToSpawnEnemy;//Time since we tried to spawn an enemy
    private float timeSinceTryingToSpawnPickup;//Time since we tried to spawn a pickup
    private float timeSinceEnemySpawned;     //Time since we spawned an enemy
    private float timeSincePickupSpawned;    //Time since we spawned a pickup
    private float timeSinceTryingToSpawnWeapon;//Time since we tried to spawn a weapon
    private float timeSiceWeaponSpawned;     //Time since we spawned a weapon

    public int currentLevel;                 //Current level name

    void Start()
    {
        //Setting variables, objects and PlayerPrefs
        currentLevel = 0;       //I set infinite mode as level 0. Normal levels start from 1.
        PlayerPrefs.SetInt("level", currentLevel);
        spawnLeft = GameObject.Find("SpawnLeft");
        spawnRight = GameObject.Find("SpawnRight");
        deserialiseWeapons();
    }

    void Update()
    {
        //Count all needed times
        timeSiceWeaponSpawned += Time.deltaTime;
        timeSinceTryingToSpawnWeapon += Time.deltaTime;
        timeSinceTryingToSpawnEnemy += Time.deltaTime;
        timeSinceTryingToSpawnPickup += Time.deltaTime;
        timeSinceEnemySpawned += Time.deltaTime;
        timeSincePickupSpawned += Time.deltaTime;
        //If we can try to spawn a weapon, use a random number to try to spawn it with some chance
        if(timeSiceWeaponSpawned > minTimeBetweenWeaponSpawns && timeSinceTryingToSpawnWeapon > delayBetweenTryingToSpawnWeapon)
        {
            timeSinceTryingToSpawnWeapon = 0f;
            float rand = Random.Range(0f, 1f);
            if(rand < chanceOfWeaponSpawning)
            {
                timeSiceWeaponSpawned = 0f;
                SpawnWeapon();
            }
        }
        //If we can try to spawn an enemy, use a random number to try to spawn it with some chance
        if (timeSinceEnemySpawned > minTimeBetweenEnemySpawns && timeSinceTryingToSpawnEnemy > delayBetweenTryingToSpawnEnemy)
        {
            timeSinceTryingToSpawnEnemy = 0f;
            float rand = Random.Range(0f, 1f);
            if (rand < chanceOfWeaponSpawning)
            {
                timeSinceEnemySpawned = 0f;
                SpawnEnemy();
            }
        }
        //If we can try to spawn a pickup, use a random number to try to spawn it with some chance
        if (timeSincePickupSpawned > minTimeBetweenPickupsSpawns && timeSinceTryingToSpawnPickup > delayBetweenTryingToSpawnPickup)
        {
            timeSinceTryingToSpawnPickup = 0f;
            float rand = Random.Range(0f, 1f); 
            if (rand < chanceOfPickupSpawning) 
            {
                timeSincePickupSpawned = 0f; 
                SpawnPickup();
            }
        }
        //Cheat codes for debugging
        if (Input.GetKey(KeyCode.Q))
        {
            SpawnWeapon();
        }
        if (Input.GetKey(KeyCode.E))
        {
            SpawnEnemy();
        }
        if(Input.GetKey(KeyCode.R))
        {
            SpawnPickup();
        }

    }

    //Choose one weapon to spawn with equal chance
    void SpawnWeapon()
    {
        int randForChoice = Random.Range(0, 6);

        //Choose randomly in which spawn point the weapon will appear
        float randForSide = Random.Range(0f, 1f);
        if (randForSide < 0.5f)
        {
            Instantiate(weaponsPrefabs[randForChoice], spawnLeft.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(weaponsPrefabs[randForChoice], spawnRight.transform.position, Quaternion.identity);
        }

    }

    void SpawnEnemy()
    {
        float randForChoice = Random.value;
        float cumulative = 0f;
        //Go through all chances of spawning enemies and randomly choose one
        for (int i = 0; i < chanceOfEnemyChoice.Length; i++)
        {
            cumulative += chanceOfEnemyChoice[i];

            if (randForChoice <= cumulative)
            {
                //The harder the chosen enemy, the longer it will take to spawn the next one.
                if (i == 0)
                {
                    delayBetweenTryingToSpawnEnemy = 0.5f;
                    minTimeBetweenEnemySpawns = 0.5f;
                }
                else if (i == 1)
                {
                    delayBetweenTryingToSpawnEnemy = 1f;
                    minTimeBetweenEnemySpawns = 2f;
                }
                else if (i == 2)
                {
                    delayBetweenTryingToSpawnEnemy = 5f;
                    minTimeBetweenEnemySpawns = 15f;
                }
                //Choose randomly in which spawn point the enemy will appear
                float randForSide = Random.Range(0f, 1f);
                if (randForSide < 0.5f)
                {
                    Instantiate(enemiesPrefabs[i], spawnLeft.transform.position + getPositionOffset(), Quaternion.identity);
                }
                else
                {
                    Instantiate(enemiesPrefabs[i], spawnRight.transform.position+getPositionOffset(), Quaternion.identity);
                }

                break;
            }
        }
    }

    void SpawnPickup()
    {
        //All 3 pickups have the same chance of spawning
        int randForChoice = Random.Range(0, 3);
        int i = 0;
        switch(randForChoice)
        {
               case 0:
                i = 0;
                    break;
                case 1:
                    i = 1;
                    break;
                case 2:
                    i = 2;
                    break;
            case 3:
                i = 3;
                break;
        }
        //Choose randomly in which spawn point the pickup will appear
                float randForSide = Random.Range(0f, 1f);
                if (randForSide < 0.5f)
                {
                    Instantiate(pickupsPrefabs[i], spawnLeft.transform.position + getPositionOffset(), Quaternion.identity);
                }
                else
                {
                    Instantiate(pickupsPrefabs[i], spawnRight.transform.position + getPositionOffset(), Quaternion.identity);
                }

            
            
        
    }
    //Get a random position offset from spawnpoint to make all prefabs not spawn in exactly same place
    Vector3 getPositionOffset()
    {
        Vector3 offset = new Vector3(0, 0, 0);
        float randForSide = Random.Range(-5f, 5f);
        offset.x = randForSide;
        return offset;
    }
    //Read bought weapons from PlayerPrefs and make an array of them
    void deserialiseWeapons()
    {
        string weapons = PlayerPrefs.GetString("weapons");
        if (!string.IsNullOrEmpty(weapons) && weapons.Length == 7)
        {
            for (int i = 0; i < 7; i++)
            {
                unlockedWeapons[i] = weapons[i] == '1' ? 1 : 0;
            }
        }
    }
}
