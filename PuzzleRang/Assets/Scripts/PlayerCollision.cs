using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerCollision : MonoBehaviour
{
    private int healthPoints = 4;
    public GameObject enemy;
    public bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0)
        {
            GameOver = true;
            Debug.Log("Game Over");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            healthPoints--;
            Debug.Log(healthPoints);
            Destroy(other.gameObject);
        }
    }
}
