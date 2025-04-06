using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameController : MonoBehaviour
{
    public GameObject[] weaponsPrefabs;
    public GameObject spawnLeft;
    public GameObject spawnRight;

    public int[] unlockedWeapons;
    public float[] chanceOfWeaponChoice;
    public float chanceOfWeaponSpawning;
    public float timeSiceWeaponSpawned;
    public float minTimeBetweenWeaponSpawns;
    public float delayBetweenTryingToSpawnWeapon;
    public float timeSinceTryingToSpawnWeapon;

    // Start is called before the first frame update
    void Start()
    {
        spawnLeft = GameObject.Find("SpawnLeft");
        spawnRight = GameObject.Find("SpawnRight");
    }

    // Update is called once per frame
    void Update()
    {
        timeSiceWeaponSpawned += Time.deltaTime;
        timeSinceTryingToSpawnWeapon += Time.deltaTime;

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

        if(Input.GetKey(KeyCode.Q))
        {
            SpawnWeapon();
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
}
