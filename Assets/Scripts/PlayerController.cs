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

    public TextMeshProUGUI scoreHud;
    public TextMeshProUGUI coinHud;

    Rigidbody rb;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * GameManager.instance.moveSpeed * Time.deltaTime);

        scoreHud.text = Mathf.FloorToInt(transform.position.z).ToString();
        coinHud.text = GameManager.instance.coins.ToString();

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
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            isAlive = false;
            GameManager.instance.moveSpeed = 0;
            animator.SetTrigger("Death");

            GameManager.instance.distance = transform.position.z;
            GameManager.instance.score = Mathf.FloorToInt(GameManager.instance.distance) + GameManager.instance.coins;
        }
    }
}
