using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeReference]
    GameObject UIInstruction;

    public void PlayGame()
    {
        //GetComponent<AudioSource>().Play();
        GameObject.Find("MainMenu").SetActive(false);
        UIInstruction.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
