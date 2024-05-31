using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_2 : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> spawnables = new();

    private readonly KeyCode initialKey = KeyCode.Alpha1;
    private readonly List<KeyCode> keybinds = new();

    private List<GameObject> spawned = new();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnables.Count; i++)
        {
            keybinds.Add(initialKey + i);
        }

        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        for (int reps = 0; reps < 3; reps++)
        {
            for (int i = 0; i < spawnables.Count; i++)
            {
                var new_spawn = Instantiate(spawnables[i], this.transform.position, Quaternion.identity, null);
                spawned.Add(new_spawn);

                yield return new WaitForSeconds(0.4f);
            }
        }

        yield return new WaitForSeconds(1f);

        foreach (var spawn in spawned)
        {
            spawn.SetActive(false);
        }
        spawned.Clear();

        yield return SpawnRoutine();
    }
}
