using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinsturzParticleScript : MonoBehaviour
{
    
	public float xSpeed = 0.001f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (transform.position.x+xSpeed, transform.position.y, transform.position.z);
    }
}
