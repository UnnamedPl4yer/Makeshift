using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMovement : MonoBehaviour
{
    private Rigidbody fox;
    public Animator foxAnimator;
    public Rigidbody bird;
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    private bool isJumping = false;
    public static bool isDigging = false;
    private float waitTilDestroy = 5f;

    // Start is called before the first frame update
    void Start()
    {
        fox = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
            {
                Debug.Log("Hit " + hit.collider.transform.name);
                if (hit.transform.name == "TunnelEntry")
                {
                    Debug.Log("burrowing");
                    GrabenScript.ready = true;
                    isDigging = true;
                    StartCoroutine(Sleep());
                    //Destroy(hit.collider.gameObject);
                }
            }
        }

        //Debug.Log(GlobalHandler.lever1);
        if (Input.GetKeyDown(KeyCode.R))
        {
            fox.transform.position = CheckPointManager.latestCheckpoint;
            bird.transform.position = CheckPointManager.latestCheckpoint;
            Debug.Log("Respawned both Characters!");
        }
    }

    IEnumerator Sleep()
    {
        yield return new WaitForSecondsRealtime(5);
    }

    private void FixedUpdate()
    {
        if (!isDigging)
        {
            float moveInput = Input.GetAxis("HorizontalFox");
            fox.velocity = new Vector3(moveInput * moveSpeed, fox.velocity.y, 0);
            foxAnimator.SetInteger("speed", (int) (moveInput*moveSpeed));
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping &&!isDigging)
        {
            fox.velocity = new Vector3(fox.velocity.x, jumpSpeed, 0);
            isJumping = true;
            foxAnimator.SetBool("jumping", true);
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "floor" || coll.gameObject.tag == "Tunnel")
        {
            isJumping = false;
            foxAnimator.SetBool("jumping", false);
        }


        if (coll.gameObject.tag == "Lever1")
        {
            Debug.Log("Fox touched Lever1");
            GlobalHandler.lever1 = true;
            //GameObject castle = HelperFunctions.GetParent(coll.gameObject);
            //GameObject gate = HelperFunctions.FindChildWithTag(castle.transform, "MoveableBlock");
            //anim.Play("GateOpenAnim", 0 , 0);
        }

        if (coll.gameObject.tag == "DeathObject")
        {
            transform.position = CheckPointManager.latestCheckpoint;
            bird.transform.position = CheckPointManager.latestCheckpoint + new Vector3(1, 0, 0);
        }
    }

    private void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.name == "MoveableBlock")
        {
            fox.velocity *= 0.5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
            CheckPointManager.SetCheckpoint(other.transform.position);

        //if (other.tag == "TheEnd")
        //  SceneManager.LoadScene("End");
    }
}
