using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    public static readonly List<Pickupable> pickupables = new();
    public static int currentscore { get; private set; }

    private void Awake()
    {
        if (pickupables.Contains(this) == false)
        {
            pickupables.Clear();

            foreach (var pickup in FindObjectsByType<Pickupable>(0))
                pickupables.Add(pickup);
        }
    }

    public void Pickup()
    {
        this.gameObject.SetActive(false);
        currentscore++;
    }

    public static void Reset()
    {
        currentscore = 0;

        foreach (var pickup in pickupables)
        {
            pickup.gameObject.SetActive(true);
        }
    }
}
