using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{

    public GameObject treePrefab;
    public int treeCount = 80;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < treeCount; i++)
        {
            Vector3 randomSpawn = new Vector3(Random.Range(-50, 60), 10, Random.Range(10, 50));
            Instantiate(treePrefab, randomSpawn, Quaternion.identity);
        }
    }
}
