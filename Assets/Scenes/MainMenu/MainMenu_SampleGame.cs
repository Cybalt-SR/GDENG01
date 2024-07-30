using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_SampleGame : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("White Room");
    }

    public void Help()
    {
        SceneManager.LoadScene("HowtoPlay");
        Cursor.visible = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
