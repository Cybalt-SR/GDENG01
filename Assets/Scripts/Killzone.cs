using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Killzone : MonoSingleton<Killzone>
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player.Instance.gameObject)
        {
            Die();
        }
    }

    public void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoseScreen");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
