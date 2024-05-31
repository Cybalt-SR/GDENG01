using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_1 : MonoBehaviour
{
    [SerializeField]
    private List<Transform> positionRefs = new();
    [SerializeField]
    private GameObject spawnable;

    private GameObject spawned;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        for (int i = 0; i < positionRefs.Count; i++)
        {
            var new_spawn = Instantiate(spawnable, positionRefs[i].position, Quaternion.identity, null);
            spawned = new_spawn;

            yield return new WaitForSeconds(0.8f);
            spawned.SetActive(false);
        }

        yield return SpawnRoutine();
    }
}
