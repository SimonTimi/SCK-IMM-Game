using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public GameObject bulletPrefab;
    // Lifetime for each bullet in seconds
    public float bulletLifetime = 2f;
    private int ammo = 20;
    private bool isReloading = false;
    private AudioSource playerAudio;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ammo > 0 && !isReloading)
        {
            SpawnBullet();
            ammo --;
            //playerAudio.PlayOneShot(drumGun, 1.0f);
            GameManager.Instance.PlaySFXByIndex(0);
        }

        else if ((ammo <= 0 && !isReloading) || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReloadAmmo());
            //playerAudio.PlayOneShot(relaod, 1.0f);
            GameManager.Instance.PlaySFXByIndex(1);
        }
    }

    void SpawnBullet()
    {
        // Instantiate the bullet at the player's position and rotation, but not as a child of the player
        GameObject bullet = Instantiate(bulletPrefab, player.transform.position, player.transform.rotation);
        
        // Optionally, set the bullet's speed if controlled by the BulletMovement script
        BulletMovement bulletMovement = bullet.GetComponent<BulletMovement>();
        if (bulletMovement != null)
        {
            bulletMovement.speed = speed;
        }

         Destroy(bullet, bulletLifetime);
    }

    IEnumerator ReloadAmmo()
    {
        isReloading = true;
        yield return new WaitForSeconds(3f); 
        ammo = 20; // Reset ammo count
        isReloading = false;
    }
}
