using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public float distance;
    public int coins;

    public int highScore;

    public float moveSpeed = 10f;

    public bool isPaused;

    public float musicVolume = 0.5f;
    public float soundVolume = 0.5f;

    public static GameManager instance;
    public AudioSource musicSource;
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        musicSource = GetComponent<AudioSource>();
    }
}
