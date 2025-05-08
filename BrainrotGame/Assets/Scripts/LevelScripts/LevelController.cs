using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    //Script like Game Controller but for pre-designed levels.
    //It handles spawning enemies, powerups and weapons.

    public GameObject[] wavesTypes;         //Array of chosen prefabs that will be spawned in a wave
    public int[] wavesValue;                //Array of how many of each prefab will be spawned in a wave
    public float[] wavesTimes;              //Array of how long until next wave will be spawned
    public int actualWaveIndex;             //Index of the wave that was just spawned (Starts from 0)

    public GameObject[] weaponsPrefabs;     //Array of all weapons prefabs in the game
    public GameObject spawnLeft;            //Empty spawn point
    public GameObject spawnRight;           //Empty spawn point

    public int[] unlockedWeapons;           //Array of weapons bought by the player (from PlayerPrefs, 1 = bought)
    public float[] chanceOfWeaponChoice;    //How likely is each weapon to spawn (sum of all values should be 1)
    //To spawn a weapon in a wave, we put any weapon prefab in wavesTypes. It will be then randomly chosen from unlocked ones.
    public float timeSinceLastWave;         //Time since last wave was spawned
    public int currentLevel;                //Number of current level

    void Start()
    {
        //Find all objects and get PlayerPrefs ready
        actualWaveIndex = 0;
        currentLevel = int.Parse(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("level", currentLevel);
        spawnLeft = GameObject.Find("SpawnLeft");
        spawnRight = GameObject.Find("SpawnRight");
        deserialiseWeapons();
    }

    void Update()
    {
        if (actualWaveIndex > wavesTypes.Length || actualWaveIndex > wavesValue.Length)
        {
            return; //Do nothing if we are out of waves
        }
        if (actualWaveIndex < wavesTimes.Length) //If we have some waves to spawn
        {
            if(timeSinceLastWave > wavesTimes[actualWaveIndex]) //If it is time to spawn a wave
            {
                //Check if prefab is one of the enemies of powerups
                if (wavesTypes[actualWaveIndex].name == "EnemySuzanne" || wavesTypes[actualWaveIndex].name == "EnemyDragon 1" || wavesTypes[actualWaveIndex].name == "EnemyTeapot" ||
                    wavesTypes[actualWaveIndex].name == "DamageUp" || wavesTypes[actualWaveIndex].name == "DamageDown" || wavesTypes[actualWaveIndex].name == "Immunity" || wavesTypes[actualWaveIndex].name == "Health")
                {
                    for (int i = 0; i < wavesValue[actualWaveIndex]; i++)
                    {
                        //Spawn the prefab the amount of times known from wavesValue
                        SpawnEnemyOrPowerup(wavesTypes[actualWaveIndex]);
                    }
                    actualWaveIndex++;
                }
                else
                {
                    //If the prefab didn't match anything, just spawn a random weapon
                    SpawnWeapon();
                    actualWaveIndex++;
                }
                timeSinceLastWave = 0;  
            }

        }

        timeSinceLastWave += Time.deltaTime;
    }

    //Spawns a random from unlocked weapons at random side of the screen
    //Chance of which of unlocked weapon will spawn is defined in chanceOfWeaponChoice
    void SpawnWeapon()
    {
        float randForChoice = Random.value;
        float cumulative = 0f;

        //Function that randomly goes through chances of unlocking weapons and chooses one
        for (int i = 0; i < chanceOfWeaponChoice.Length; i++)
        {
            cumulative += chanceOfWeaponChoice[i];
            if (randForChoice <= cumulative)
            {
                if (unlockedWeapons[i] == 0)
                {
                    return;
                }
                //Choose randomly in which spawn point the weapon will appear
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

    //Spawns an enemy or powerup from chosen prefab at random of specified spawnpoints
    void SpawnEnemyOrPowerup(GameObject gameobject)
    {
        //Offset makes many enemies not spawn in exactly same place
        Vector3 offset = getPositionOffset();
        //Chose spawnpoint randomly from set ones
        float randForSide = Random.Range(0f, 1f);
        if (randForSide < 0.5f)
        {
            Instantiate(gameobject, spawnLeft.transform.position + offset, Quaternion.identity);
        }
        else
        {
            Instantiate(gameobject, spawnRight.transform.position + offset, Quaternion.identity);
        }


    }

    //Function that returns a random position offset in which prefab will be spawned from spawnpoint
    Vector3 getPositionOffset()
    {
        Vector3 offset = new Vector3(0, 0, 0);
        float randForSideX = Random.Range(-1.8f, 1.8f);
        float randForSideZ = Random.Range(-5f, 5f);
        offset.x = randForSideX;
        offset.z = randForSideZ;
        return offset;
    }

    //Function that gets info about unlocked weapons from PlayerPrefs and changes it to the array
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
