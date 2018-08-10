using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGameBtn(string StartGameLevel)
    {
        SceneManager.LoadScene(StartGameLevel);
    }

    public void ExitToMenuBtn(string GoToMenu)
    {
        SceneManager.LoadScene(GoToMenu);
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }
}