using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager: MonoBehaviour
{
    public static Vector3 latestCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        latestCheckpoint = transform.GetChild(0).transform.position;
        Debug.Log(latestCheckpoint);
    }

    public static void SetCheckpoint(Vector3 newCheckpoint)
    {
        if (newCheckpoint.x > latestCheckpoint.x)
        {
            latestCheckpoint = newCheckpoint;
            Debug.Log("CheckPoint Updated!");
        }
    }
}
