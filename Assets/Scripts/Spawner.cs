using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<Transform> spawnpoints;

    int spawn_index;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 3, 15);
    }

    void Spawn()
    {
        Instantiate(prefab, spawnpoints[spawn_index].position, Quaternion.identity, null);

        spawn_index++;
        spawn_index %= spawnpoints.Count;
    }
}
