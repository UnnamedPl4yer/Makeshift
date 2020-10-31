using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverControl : MonoBehaviour
{
    private Animator anim;
    public static bool switched = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Fox" || coll.gameObject.tag == "Bird")
        {
            switched = true;
            anim.SetBool("Switch", true);
        }
    }
}
