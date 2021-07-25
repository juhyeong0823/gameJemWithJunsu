using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour // ��ǻ� ī�޶� ���ư��� �̴ϴ�.
{
    public float speed;
    private bool canRotate = false;

    private void Awake()
    {
        Invoke("CanRotate", 2f);
    }

    void Update()
    {
        if (!canRotate) return;
        transform.Rotate(0f, Input.GetAxis("Mouse X") * speed, 0f, Space.World);
        transform.Rotate(-Input.GetAxis("Mouse Y") * speed, 0f, 0f);
    }

    void CanRotate()
    {
        canRotate = true;
    }
}
