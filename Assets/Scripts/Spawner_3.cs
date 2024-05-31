using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_3 : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;

    private List<GameObject> spawned = new();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        var new_spawn = Instantiate(cube, this.transform.position, Quaternion.identity, null);
        new_spawn.transform.localScale = Vector3.one * 3;
        spawned.Add(new_spawn);

        yield return new WaitForSeconds(1f);

        new_spawn.SetActive(false);

        for (int i = 0; i < 50; i++)
        {
            new_spawn = Instantiate(cube, this.transform.position, Quaternion.identity, null);
            new_spawn.transform.localScale = Vector3.one * 0.5f;
            spawned.Add(new_spawn);
        }

        yield return new WaitForSeconds(2f);

        foreach (var spawn in spawned)
        {
            spawn.SetActive(false);
        }
        spawned.Clear();

        yield return SpawnRoutine();
    }
}
