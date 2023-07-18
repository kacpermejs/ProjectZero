using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private Transform parent;

    public void Spawn()
    {
        Instantiate(prefabToSpawn, parent);
    }
}
