using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MaxRange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x > 24)
        {
            transform.position = new Vector3(24, 0, gameObject.transform.position.z);
        }
        else if (gameObject.transform.position.x < -24)
        {
            transform.position = new Vector3(-24, 0, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.z > 33)
        {
            transform.position = new Vector3(gameObject.transform.position.x, 0, 33);
        }
        else if (gameObject.transform.position.z < -13)
        {
            transform.position = new Vector3(gameObject.transform.position.x, 0, -13);
        }
    }
}
