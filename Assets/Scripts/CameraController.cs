using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public bool root;

    public Transform player;
    public float camLockSpeed = 5f;

    void Update()
    {
        if (root)
        {
            transform.Translate(Vector3.forward * GameManager.instance.moveSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 direcao = player.position - transform.position;
            Quaternion rotacaoDesejada = Quaternion.LookRotation(direcao);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoDesejada, camLockSpeed * Time.deltaTime);
        }
    }
}
