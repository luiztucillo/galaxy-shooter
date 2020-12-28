using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float horizontalSpeed = 10;
    
    [SerializeField]
    private float verticalSpeed = 10;

    [SerializeField]
    private GameObject fire;

    [SerializeField]
    private int firesPerSecond = 1;
    
    [SerializeField]
    private int hp = 100;
    
    [SerializeField]
    private float distance = 0f;
    
    private GameObject _defaultFire;
    private float _lastFire;
    private UIManager _uiManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _defaultFire = fire;
        transform.position = new Vector3(0, 0, 0);
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();

        distance++;
    }

    private void Fire()
    {
        if (Input.GetButton("Fire1"))
        {
            if (_lastFire == 0.00f || Time.time - _lastFire >= 1.00f / firesPerSecond)
            {
                Instantiate(fire, transform.position, Quaternion.identity);
                _lastFire = Time.time;
            }
        }
    }
    
    private void Move()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
            
        transform.Translate(Vector3.right * (horizontalInput * (horizontalSpeed * Time.deltaTime)));
        transform.Translate(Vector3.up * (verticalInput * (verticalSpeed * Time.deltaTime)));

        var position = transform.position;
        position = new Vector3(
            position.x > 8 ? 8 : (position.x < -8 ? -8 : position.x), 
            position.y > 0 ? 0 : (position.y < -4 ? -4 : position.y), 
            0
        );
        transform.position = position;
    }

    public void SetPowerup(GameObject powerup)
    {
        fire = powerup;
        StartCoroutine(RemovePowerup());
    }

    public void Collide(int hpLost)
    {
        hp -= hpLost;
        
        if (hpLost > 0) return;
        
        Destroy(gameObject);
    }
    
    private IEnumerator RemovePowerup()
    {
        yield return new WaitForSeconds(5f);
        fire = _defaultFire;
    }

    public float GetDistance()
    {
        return distance;
    }
}
