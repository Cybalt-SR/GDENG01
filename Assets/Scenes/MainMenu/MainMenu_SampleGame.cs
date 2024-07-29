using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_SampleGame : MonoBehaviour
{
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
