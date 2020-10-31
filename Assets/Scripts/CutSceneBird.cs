using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneBird : MonoBehaviour
{
    private Rigidbody bird;
    public Animator birdAnimator;
    public Rigidbody fox;
	public AudioSource sound;

    private float speed = 3f;
    private bool autoMove = true;
    private bool chase = false;
    private bool jump = false;
	
	

    private Vector3 vel;

    // Start is called before the first frame update
    void Start()
    {
        bird = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        birdAnimator.SetInteger("movementDirection", (int)bird.velocity.x);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "CutSceneTerrain")
        {
            bird.velocity = new Vector3(-speed, 0, 0);
            birdAnimator.SetInteger("flyingMovement", -1);
        }

        if (collision.gameObject.tag == "floor")
            bird.velocity = new Vector3(speed, 0, 0);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "CutSceneTerrain")
            bird.velocity = new Vector3(-speed, speed, 0);
			
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "AutomaticEnd")
        {
            bird.transform.position = new Vector3(8.5f, 3.07f, 0);
            bird.velocity = new Vector3(0, 0, 0);
            bird.angularVelocity = new Vector3(0, 0, 0);
			StartCoroutine (AudioFadeOut.FadeOut (sound, 10f));
        }

        if (other.gameObject.name == "BeginManualBird")
        {
            //CutSceneFox.chase = true;
            //CutSceneFox.followBird = true;
            bird.GetComponent<BirdMovement>().enabled = true;
            bird.GetComponent<CutSceneBird>().enabled = false;
        }
    }
}
