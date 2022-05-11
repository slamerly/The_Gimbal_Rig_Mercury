using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                //Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Camera.main.GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        GamePaused = false;
    }



    void Pause()
    {
        Camera.main.GetComponent<AudioSource>().Play();
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        GamePaused = true;
    }

    public void NewGame()
    {
        Camera.main.GetComponent<AudioSource>().Play();
        GamePaused = false;
        StaticClassCrossScene.DifficultyMenu = true;
        SceneManager.LoadScene("Menu");
    }

    public void LoadMenu()
    {
        Camera.main.GetComponent<AudioSource>().Play();
        GamePaused = false;
        SceneManager.LoadScene("Menu");
    }
}
