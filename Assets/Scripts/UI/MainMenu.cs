using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeReference]
    GameObject UIInstruction;
    [SerializeReference]
    GameObject UIDifficulties;

    private void Update()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
        if (StaticClassCrossScene.DifficultyMenu)
        {
            GameObject.Find("MainMenu").SetActive(false);
            UIDifficulties.SetActive(true);
            StaticClassCrossScene.DifficultyMenu = false;
        }
    }

    public void PlayGame()
    {
        Camera.main.GetComponent<AudioSource>().Play();
        GameObject.Find("MainMenu").SetActive(false);
        UIInstruction.SetActive(true);
    }

    public void QuitGame()
    {
        Camera.main.GetComponent<AudioSource>().Play();
        Debug.Log("Quit");
        Application.Quit();
    }
}
