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
        //GetComponent<AudioSource>().Play();
        GameObject.Find("Instruction").SetActive(false);
        UIInstruction.SetActive(true);
    }

    public void PlayGameEasy()
    {
        //GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        StaticClassCrossScene.Difficulty = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGameMedium()
    {
        //GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        StaticClassCrossScene.Difficulty = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGameHard()
    {
        //GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        StaticClassCrossScene.Difficulty = 2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
