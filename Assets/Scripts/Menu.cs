using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject inGameMenu;
    public GameObject menuPause;
    public GameObject menuSettings;

    public Slider musicVolume;
    AudioSource musicSource;

    void Start()
    {
        if (menuPause != null) menuPause.SetActive(true);
        if (inGameMenu != null) inGameMenu.SetActive(false);
        menuSettings.SetActive(false);

        musicSource = GameManager.instance.musicSource;
        musicVolume.value = GameManager.instance.musicVolume;
        musicVolume.onValueChanged.AddListener(delegate { UpdateVolume(); });
    }

    void UpdateVolume()
    {
        GameManager.instance.musicVolume = musicVolume.value;
        musicSource.volume = musicVolume.value;
    }

    public void PlayButton()
    {
        // Reset Stats.
        GameManager.instance.isPaused = false;
        GameManager.instance.moveSpeed = 10f;
        GameManager.instance.coins = 0;
        Time.timeScale = 1f;

        SceneManager.LoadScene("Game");
    }

    public void PauseButton()
    {
        if (!inGameMenu.activeSelf)
        {
            GameManager.instance.isPaused = true;
            Time.timeScale = 0f;

            inGameMenu.SetActive(true);
        }
        else
        {
            GameManager.instance.isPaused = false;
            Time.timeScale = 1f;

            inGameMenu.SetActive(false);
        }
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

    public void ResumeButton()
    {
        Time.timeScale = 1f;

        inGameMenu.SetActive(false);
    }

    public void MainMenuButton()
    {
        // Reset Stats.
        GameManager.instance.isPaused = false;
        GameManager.instance.moveSpeed = 10f;
        GameManager.instance.coins = 0;
        Time.timeScale = 1f;

        SceneManager.LoadScene("Menu");
    }
}
