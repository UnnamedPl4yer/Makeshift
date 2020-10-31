using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabenScript : MonoBehaviour
{
    
	private ParticleSystem ps;
	public Rigidbody fox_rb;
    public Animator foxAnimator;
	public static bool ready;
    private int count = 0;
    public GameObject ground;
    public GameObject facade;
    public GameObject facadePrefab;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
		ready = false;
        ps.Stop();
        facadePrefab = Resources.Load("facadePrefab") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
		if (!ready)
		{
			if (!ps.isEmitting)
			{
				ps.Stop();
                if (FoxMovement.isDigging == true)
                {
                    foxAnimator.SetBool("digging", false);
                    Destroy(ground);
                    Instantiate(facadePrefab, facade.transform.position, facade.transform.rotation);
                    Destroy(facade);
                }
                FoxMovement.isDigging = false;
			}
		}
		
		else
		{
			transform.position = new Vector3(fox_rb.transform.position.x, fox_rb.transform.position.y+1, fox_rb.transform.position.z);
            ps.Play();
            foxAnimator.SetBool("digging", true);
			ready = false;
		}
    }
}
