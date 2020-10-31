using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBehaviour : MonoBehaviour
{
    private GameObject RopeDestroyedLong;
    private GameObject RopeDestroyedShort;
    private GameObject Log;
    private Vector3 parentRopePosition;

    private void Start()
    {
        RopeDestroyedLong = Resources.Load("Env/RopeLong") as GameObject;
        RopeDestroyedShort = Resources.Load("Env/RopeShort") as GameObject;
        Log = Resources.Load("Env/Log") as GameObject;
        parentRopePosition = transform.position;
    }

    public static void DestroyRope()
    {
        //Instantiate(RopeDestroyedLong)
    }
}
