using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 60.0f;

    void Update()
    {
        // Move the bullet forward constantly at the given speed
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
