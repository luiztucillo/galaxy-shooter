using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private int hp = 100;

    [SerializeField]
    private GameObject explosion;

    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        Reposition();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * (speed * Time.deltaTime));

        if (transform.position.y < -6)
        {
            Reposition();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player == null) return;
            player.Collide(30);
            Collide(60);
        }
    }

    public void Collide(int hpLost)
    {
        hp -= hpLost;
        
        if (hp <= 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        speed = 0;
        _uiManager.updateScore(10);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    private void Reposition()
    {
        transform.position = new Vector3(Random.Range(-5f, 5f), 6);
    }
}
