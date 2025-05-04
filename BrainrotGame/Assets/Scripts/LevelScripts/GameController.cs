using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject[] wavesTypes;
    public int[] wavesValue;
    public float[] wavesTimes;
    public int actualWaveIndex;

    public GameObject[] weaponsPrefabs;
    public GameObject spawnLeft;
    public GameObject spawnRight;

    public int[] unlockedWeapons;
    public float[] chanceOfWeaponChoice;
    public float[] chanceOfEnemyChoice;
    public float chanceOfWeaponSpawning;

    public float timeSinceLastWave;

    public int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        actualWaveIndex = 0;
        currentLevel = int.Parse(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("level", currentLevel);
        spawnLeft = GameObject.Find("SpawnLeft");
        spawnRight = GameObject.Find("SpawnRight");
        deserialiseWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        if (actualWaveIndex > wavesTypes.Length || actualWaveIndex > wavesValue.Length)
        {
            return; // Prevent out-of-bounds errors
        }
        if (actualWaveIndex < wavesTimes.Length)
        {
            if(timeSinceLastWave > wavesTimes[actualWaveIndex])
            {
                if (wavesTypes[actualWaveIndex].name == "EnemySuzanne" || wavesTypes[actualWaveIndex].name == "EnemyDragon 1" || wavesTypes[actualWaveIndex].name == "EnemyTeapot" ||
                    wavesTypes[actualWaveIndex].name == "DamageUp" || wavesTypes[actualWaveIndex].name == "DamageDown" || wavesTypes[actualWaveIndex].name == "Immunity" || wavesTypes[actualWaveIndex].name == "Health")
                {
                    for (int i = 0; i < wavesValue[actualWaveIndex]; i++)
                    {
                        SpawnEnemyOrPowerup(wavesTypes[actualWaveIndex]);
                    }
                    actualWaveIndex++;
                }
                else
                {
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

    void SpawnEnemyOrPowerup(GameObject gameobject)
    {
        Vector3 offset = getPositionOffset();
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

    Vector3 getPositionOffset()
    {
        Vector3 offset = new Vector3(0, 0, 0);
        float randForSideX = Random.Range(-1.8f, 1.8f);
        float randForSideZ = Random.Range(-5f, 5f);
        offset.x = randForSideX;
        offset.z = randForSideZ;
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
