using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public GameObject menuGameOver;

    PlayerController controller;
    private void Start()
    {
        controller = GetComponentInParent<PlayerController>();
    }

    public void goingRight()
    {
        controller.transform.position += new Vector3(2, 0.25f, 0);
    }

    public void goingLeft()
    {
        controller.transform.position += new Vector3(-2, 0.25f, 0);
    }

    public void goingUp()
    {
        GetComponentInParent<BoxCollider>().enabled = false;
    }

    public void ArrivedToTrack()
    {
        controller.canMove = true;
        GetComponentInParent<BoxCollider>().enabled = true;
    }

    public void GameOver()
    {
        menuGameOver.SetActive(true);
    }
}
