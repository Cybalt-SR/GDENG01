using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    public static readonly List<Pickupable> pickupables = new();
    public static int currentscore = 0;

    static int scoreGoal = 5;

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

    private void OnGUI()
    {
        GUILayout.Box("Masks Found : " + currentscore);
    }

    void Update()
    {
        if (currentscore >= scoreGoal)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("WinScreen");
        }
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
