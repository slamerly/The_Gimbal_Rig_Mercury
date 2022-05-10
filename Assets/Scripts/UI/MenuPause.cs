using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject playerCtrl;

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
        GetComponent<AudioSource>().Play();
        playerCtrl.GetComponent<PlayerController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        GamePaused = false;
    }

    void Pause()
    {
        playerCtrl.GetComponent<PlayerController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        GamePaused = true;
    }

    public void LoadMenu()
    {
        GetComponent<AudioSource>().Play();
        GamePaused = false;
        SceneManager.LoadScene("Menu");
    }
}
