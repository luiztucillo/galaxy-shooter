using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetDistance() % 1000 == 0)
        {
            Instantiate(enemy);
        }
    }
}
