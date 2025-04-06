using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // *** TO DO *** //
    // Make bullet move and hurt enemies
    // float speed - How fast bullet moves
    // bullet collissions should be checked only with Enemy layer.

    public float speed;
    public Enemy enemy;
    public Pigeon pigeon;

    // Start is called before the first frame update
    void Start()
    {
        pigeon = GameObject.Find("Pigeon").GetComponent<Pigeon>();

    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        Vector3 movement = new Vector3(0, 0, speed * Time.deltaTime);
        transform.position += movement;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 11)
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.takeDamage(pigeon.damage);
            }
            Destroy(gameObject);
        }
    }

}
