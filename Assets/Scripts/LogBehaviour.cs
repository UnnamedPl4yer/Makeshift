using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBehaviour : MonoBehaviour
{
    public GameObject LogToReplace;
    public GameObject LogToReplaceWith;
    private int ropeLife = 5;
    private bool destroyed = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Bird" && !destroyed)
        {
            if (other.tag == "Bird" && Input.GetKeyDown(KeyCode.E) && ropeLife > 0)
                ropeLife--;

            if (ropeLife == 0)
            {
                Instantiate(LogToReplaceWith, LogToReplace.transform.position, LogToReplace.transform.rotation);
                Destroy(LogToReplace);
                destroyed = true;
            }
        }
    }
}
