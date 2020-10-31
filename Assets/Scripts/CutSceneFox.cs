using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneFox : MonoBehaviour
{
    private Rigidbody fox;
    public Animator foxAnimator;
    public Rigidbody bird;

    private float speed = 3.5f;
    private bool jumped = false;
    public static bool followBird = false;

    // Start is called before the first frame update
    void Start()
    {
        fox = GetComponent<Rigidbody>();
        foxAnimator.SetBool("running", true);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!followBird && jumped)
            fox.velocity = new Vector3(0.5f * speed, -speed, 0);
        */
        if (jumped)
            foxAnimator.SetBool("running", false);
        if (followBird)
            fox.velocity = new Vector3(speed, 0, 0);
            
        foxAnimator.SetInteger("speed", (int)fox.velocity.x);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "floor")
            fox.velocity = new Vector3(speed, 0, 0);

        if (coll.gameObject.tag == "Bird")
        {
            //bird.transform.position = new Vector3(21, 22, 0);
            //fox.transform.position = new Vector3(26, 21.5f, 0);
            bird.transform.position = new Vector3(8.5f, 3, 0);
            fox.transform.position = new Vector3(8.5f, 0.5f, 0);
        }
    }

    private void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "floor")
        {
            Debug.Log("Contact!");
            fox.velocity = new Vector3(speed, 0, 0);
        }
            
        if (coll.gameObject.tag == "CutSceneTerrain" && !jumped)
            fox.velocity = new Vector3(-speed, 0, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "floorSubst")
        {
            //Debug.Log("Contact!");
            fox.velocity = new Vector3(speed, fox.velocity.y, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "floorSubst")
            followBird = true;
    }

    private void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.tag == "CutSceneTerrain" && !jumped)
        {
            fox.velocity = new Vector3(-speed * 0.5f, speed, 0);
            foxAnimator.SetBool("jumping", true);
            jumped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "floorSubst")
            foxAnimator.SetBool("jumping", false);

        if (other.gameObject.name == "BeginManualFox")
            SceneManager.LoadScene("TestLevel");
    }
}
