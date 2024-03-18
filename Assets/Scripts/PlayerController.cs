using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    public bool isAlive = true;
    public bool canMove = true;
    float jumpForce = 600f;

    [SerializeField]
    float timeScale = 1;

    public TextMeshProUGUI distanceHud;
    public TextMeshProUGUI coinHud;

    public TextMeshProUGUI scoreFinal;
    public TextMeshProUGUI distanceFinal;
    public TextMeshProUGUI coinFinal;
    public TextMeshProUGUI highScore;

    Rigidbody rb;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

        // Reset Stats.
        isAlive = true;
        canMove = true;
    }

    void Update()
    {
        if (GameManager.instance.isPaused) return;

        // Constantly moves player foward.
        transform.Translate(Vector3.forward * GameManager.instance.moveSpeed * Time.deltaTime);

        // Update HUD Score.
        distanceHud.text = Mathf.FloorToInt(transform.position.z).ToString();
        coinHud.text = GameManager.instance.coins.ToString();

        // Time speed should double every 150 seconds.
        if (timeScale < 3.5f) timeScale += Time.deltaTime/150;
        Time.timeScale = timeScale;
    }

    public void ButtonGoRight()
    {
        if (isAlive && canMove)
        {
            canMove = false;
            animator.SetTrigger("GoRight");
        }
    }

    public void ButtonGoLeft()
    {
        if (isAlive && canMove)
        {
            canMove = false;
            animator.SetTrigger("GoLeft");
        }
    }

    public void ButtonGoUp()
    {
        if (isAlive && canMove)
        {
            canMove = false;
            rb.AddForce(Vector3.up * jumpForce);
            animator.SetTrigger("GoUp");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Call GameOver if player hits tag Obstacles.
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            isAlive = false;
            GameManager.instance.moveSpeed = 0;
            animator.SetTrigger("Death");

            // Update GameOver Score.
            GameManager.instance.distance = transform.position.z;
            GameManager.instance.score = Mathf.FloorToInt(GameManager.instance.distance) + GameManager.instance.coins;
            if (GameManager.instance.score > GameManager.instance.highScore)
            {
                GameManager.instance.highScore = GameManager.instance.score;
            }

            scoreFinal.text = GameManager.instance.score.ToString();
            distanceFinal.text = Mathf.FloorToInt(GameManager.instance.distance).ToString();
            coinFinal.text = GameManager.instance.coins.ToString();
            highScore.text = GameManager.instance.highScore.ToString();
}
    }
}
