using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{


    public GameObject[] enemiesPrefabs;
    public GameObject[] weaponsPrefabs;
    public GameObject[] pickupsPrefabs;
    public GameObject spawnLeft;
    public GameObject spawnRight;

    public int[] unlockedWeapons;
    public float[] chanceOfWeaponChoice;
    public float[] chanceOfEnemyChoice;
    public float chanceOfWeaponSpawning;
    public float minTimeBetweenWeaponSpawns;
    public float delayBetweenTryingToSpawnWeapon;
    public float chanceOfPickupSpawning;

    public float minTimeBetweenEnemySpawns;
    public float minTimeBetweenPickupsSpawns;
    public float delayBetweenTryingToSpawnEnemy;
    public float delayBetweenTryingToSpawnPickup;

    private float timeSinceTryingToSpawnEnemy;
    private float timeSinceTryingToSpawnPickup;
    private float timeSinceEnemySpawned;
    private float timeSincePickupSpawned;
    private float timeSinceTryingToSpawnWeapon;
    private float timeSiceWeaponSpawned;

    public int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = int.Parse(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("level", currentLevel);
        spawnLeft = GameObject.Find("SpawnLeft");
        spawnRight = GameObject.Find("SpawnRight");
        deserialiseWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        timeSiceWeaponSpawned += Time.deltaTime;
        timeSinceTryingToSpawnWeapon += Time.deltaTime;
        timeSinceTryingToSpawnEnemy += Time.deltaTime;
        timeSinceTryingToSpawnPickup += Time.deltaTime;
        timeSinceEnemySpawned += Time.deltaTime;
        timeSincePickupSpawned += Time.deltaTime;

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

    void SpawnWeapon()
    {
        float randForChoice = Random.value;
        float cumulative = 0f;

        for (int i = 0; i < chanceOfWeaponChoice.Length; i++)
        {
            cumulative += chanceOfWeaponChoice[i];
            if (randForChoice <= cumulative)
            {
                if (unlockedWeapons[i] == 0)
                {
                    return;
                }
                float randForSide = Random.Range(0f, 1f);
                if(randForSide < 0.5f)
                {
                    Instantiate(weaponsPrefabs[i], spawnLeft.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(weaponsPrefabs[i], spawnRight.transform.position, Quaternion.identity);
                }
                
                break;
            }
        }
    }

    void SpawnEnemy()
    {
        float randForChoice = Random.value;
        float cumulative = 0f;

        for (int i = 0; i < chanceOfEnemyChoice.Length; i++)
        {
            cumulative += chanceOfWeaponChoice[i];

            if (randForChoice <= cumulative)
            {
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

    Vector3 getPositionOffset()
    {
        Vector3 offset = new Vector3(0, 0, 0);
        float randForSide = Random.Range(-5f, 5f);
        offset.x = randForSide;
        return offset;
    }

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
