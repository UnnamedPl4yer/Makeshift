using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawbridgeRope : MonoBehaviour
{
    public Animator anim = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDestroy()
    {
        anim.SetBool("itShallOpen", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
