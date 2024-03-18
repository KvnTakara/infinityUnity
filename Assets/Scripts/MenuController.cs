using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.forward * (GameManager.instance.moveSpeed / 2) * Time.deltaTime);

        if (transform.position.z >= 30)
        {
            transform.position = Vector3.zero;
        }
    }
}
