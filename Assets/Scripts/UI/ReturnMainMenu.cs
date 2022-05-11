using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMainMenu : MonoBehaviour
{
    public void GoMainMenu()
    {
        Camera.main.GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void NewGame()
    {
        Camera.main.GetComponent<AudioSource>().Play();
        StaticClassCrossScene.DifficultyMenu = true;
        SceneManager.LoadScene("Menu");
    }
}
