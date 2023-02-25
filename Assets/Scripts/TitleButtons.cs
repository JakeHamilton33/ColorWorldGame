using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtons : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
