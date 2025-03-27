using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    // *** TO DO *** //
    // Make Enemies move towards player on Z axis. 
    // After they reach special box collission where pigeon is, they should stay in place
    // They should deal damage to the pigeon once every damageTime
    // They should lose health after being hit with bullet and disappear after their health is gone

    public float speed;
    public float health;
    public float damage;
    public float damageTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
