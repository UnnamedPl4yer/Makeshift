using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpener : MonoBehaviour
{
    private Animator anim;
    public Animator connectedSwitchAnimator = null;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (connectedSwitchAnimator.GetBool("Switch"))
            anim.SetBool("open", true);
    }
}
