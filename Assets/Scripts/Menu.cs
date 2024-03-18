using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject inGameMenu;
    public GameObject menuPause;
    public GameObject menuSettings;

    bool creditsAction;
    bool pauseGame;

    void Start()
    {
        if (menuPause != null) menuPause.SetActive(true);
        if (inGameMenu != null) inGameMenu.SetActive(false);
        menuSettings.SetActive(false);
    }

    private void Update()
    {
        // Credits Menu. Press anyKey to close panel.
        if (creditsAction && Input.anyKey)
        {
            creditsAction = false;
            menuSettings.SetActive(true);
        }

        // Pause/Unpause Game with Esc.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseGame)
            {
                pauseGame = true;
                Time.timeScale = 0f;

                inGameMenu.SetActive(true);
                menuPause.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                pauseGame = false;
                Time.timeScale = 1f;

                inGameMenu.SetActive(false);
                menuSettings.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void SettingsButton()
    {
        if (menuPause != null) menuPause.SetActive(false);
        menuSettings.SetActive(true);
    }

    public void BackButton()
    {
        if (menuPause != null) menuPause.SetActive(true);
        menuSettings.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void ResumeButton()
    {
        pauseGame = false;
        Time.timeScale = 1f;

        inGameMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
