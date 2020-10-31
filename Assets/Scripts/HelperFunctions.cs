using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperFunctions : MonoBehaviour
{
    public static GameObject FindChildWithTag(Transform tr, string searchTag)
    {
        for (int i = 0; i < tr.childCount; i++)
        {
            if (tr.GetChild(i).tag == searchTag)
                return tr.GetChild(i).gameObject;
        }
        return null;
    }

    public static GameObject GetParent(GameObject go)
    {
        return go.transform.parent.gameObject;
    }
}
