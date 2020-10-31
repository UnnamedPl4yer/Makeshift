using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdMovement : MonoBehaviour
{
    private Rigidbody bird;
    public Rigidbody fox;
    public Animator birdAnimator = null;
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    public float glidingFactor = 0.8f;
    private bool isFlying = false;
    public float flyingCooldownFix = 0f;
    private float flyingCooldown = 1f;
    public float pickingRange = 0.5f;
    public int jumpCountMax = 2;
    private int jumpCount = 2;

    public static bool isVisible = true;

    // Start is called before the first frame update
    void Start()
    {
        bird = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Picking");
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.right, out hit, pickingRange))
            {
                Debug.Log("Hit " + hit.collider.transform.name);
                //for the rope above the Log
                if (hit.collider.transform.name == "Rope")
                {
                    Debug.Log("Picked at " + hit.collider.transform.name);
                    RopeBehaviour.DestroyRope();
                }
                //for the rope at the drawbridge and maybe all other ropes
                if(hit.collider.transform.tag == "Rope")
                {
                    Debug.Log("Picked at " + hit.collider.transform.name);
                    
                    Destroy(hit.collider.gameObject);
                }
            }
        }

        if (CheckPointManager.latestCheckpoint.x > 190)
            jumpCountMax = 4;
    }

    private void FixedUpdate()
    { 
        float moveInput = Input.GetAxis("HorizontalBird");
        bird.velocity = new Vector3(moveInput * moveSpeed, bird.velocity.y, 0);
        birdAnimator.SetInteger("movementDirection", (int) moveInput);

        /*if (isFlying)
        {
            if (flyingCooldown > 0)
                flyingCooldown -= Time.deltaTime;
            if (flyingCooldown <= 0)
            {
                flyingCooldown = flyingCooldownFix;
                isFlying = false;
            }
        }*/

        if (Input.GetKeyDown(KeyCode.W) && jumpCount > 0)
        {
            bird.velocity = new Vector3(bird.velocity.x, jumpSpeed, 0);
            birdAnimator.SetInteger("flyingMovement", 1); //starts the FlyAnimation
            jumpCount -= 1;
        }
        if (bird.velocity.y <= 0)
            bird.velocity *= glidingFactor;

        if (Input.GetKey(KeyCode.S))
            bird.velocity = new Vector3(0, -moveSpeed, 0);
    }

    private void OnCollisionEnter(Collision coll)

    {
        if ((coll.gameObject.tag == "floor" || coll.gameObject.tag == "Fox"))
            //&& Vector3.Distance(coll.gameObject.transform.position, bird.transform.position) < 0.1f
        {
            Debug.Log("The Eagle has landed!");
            birdAnimator.SetInteger("flyingMovement", -1);
            jumpCount = jumpCountMax;
        }

        if (coll.gameObject.tag == "DeathObject")
        {
            transform.position = CheckPointManager.latestCheckpoint;
            fox.transform.position = CheckPointManager.latestCheckpoint + new Vector3(1, 0, 0);
        }

        if (coll.gameObject.tag == "Lever")
        {
            Debug.Log("Bird touched Lever");
            GlobalHandler.lever1 = true;
            //GameObject castle = HelperFunctions.GetParent(coll.gameObject);
            //GameObject gate = HelperFunctions.FindChildWithTag(castle.transform, "MoveableBlock");
            //anim.Play("GateOpenAnim", 0 , 0);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
            jumpCount = jumpCountMax;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
            CheckPointManager.SetCheckpoint(other.transform.position);

        //if (other.tag == "TheEnd")
        //  SceneManager.LoadScene("End");
    }
}
