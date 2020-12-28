using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private GameObject powerup;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * (Time.deltaTime * speed)); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            PlayerCollide(other);
        }
    }

    private void PlayerCollide(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.SetPowerup(powerup);
            Destroy(gameObject);
        }
    }
}
