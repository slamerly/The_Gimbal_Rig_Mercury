using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instruction : MonoBehaviour
{
    [SerializeReference]
    GameObject UIMainMenu;
    [SerializeReference]
    GameObject UIDifficulties;

    public void BackMenu()
    {
        //GetComponent<AudioSource>().Play();
        GameObject.Find("Instruction").SetActive(false);
        UIMainMenu.SetActive(true);
    }

    public void GoDifficulties()
    {
        //GetComponent<AudioSource>().Play();
        GameObject.Find("Instruction").SetActive(false);
        UIDifficulties.SetActive(true);
    }
}
