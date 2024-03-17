using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;

    float moveSpeed = 7.5f;
    float jumpForce = 700f;

    Rigidbody rb;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public void ButtonGoRight()
    {
        if (canMove)
        {
            canMove = false;
            animator.SetTrigger("GoRight");
        }
    }

    public void ButtonGoLeft()
    {
        if (canMove)
        {
            canMove = false;
            animator.SetTrigger("GoLeft");
        }
    }

    public void ButtonGoUp()
    {
        if (canMove)
        {
            canMove = false;
            animator.SetTrigger("GoUp");
        }
    }
}
