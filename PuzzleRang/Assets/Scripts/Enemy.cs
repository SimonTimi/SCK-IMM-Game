using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float speed = 50f;
    private Rigidbody enemyRb;
    private GameObject player;

    private AudioSource enemyAudio;
    public AudioClip deathSound;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
        transform.LookAt(player.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            enemyAudio.PlayOneShot(deathSound, 1.0f);
        }
    }
}
