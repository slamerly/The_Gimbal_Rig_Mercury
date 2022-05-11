using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulties : MonoBehaviour
{
    [SerializeReference]
    GameObject UIInstruction;

    public void BackMenu()
    {
        Camera.main.GetComponent<AudioSource>().Play();
        GameObject.Find("Difficulties").SetActive(false);
        UIInstruction.SetActive(true);
    }

    public void PlayGameEasy()
    {
        Camera.main.GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        StaticClassCrossScene.Difficulty = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGameMedium()
    {
        Camera.main.GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        StaticClassCrossScene.Difficulty = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGameHard()
    {
        Camera.main.GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        StaticClassCrossScene.Difficulty = 2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
