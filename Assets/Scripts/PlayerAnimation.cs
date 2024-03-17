using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerController controller;
    private void Start()
    {
        controller = GetComponentInParent<PlayerController>();
    }

    public void goingRight()
    {
        controller.transform.position += new Vector3(2, 0, 0);
    }

    public void goingLeft()
    {
        controller.transform.position += new Vector3(-2, 0, 0);
    }

    public void ArrivedToTrack()
    {
        controller.canMove = true;
    }
}
