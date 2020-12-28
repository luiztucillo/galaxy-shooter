using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private int power = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * (speed * Time.deltaTime));

        if (transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy == null) return;
            enemy.Collide(power);
            Destroy(gameObject);
        }
    }
}
