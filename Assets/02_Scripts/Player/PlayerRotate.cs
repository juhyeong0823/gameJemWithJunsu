using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour // 사실상 카메라가 돌아가는 겁니다.
{
    private bool canRotate = false;
    private float rotateSpeed = 1500f;

    private void Awake()
    {
        Invoke("CanRotate", 1.5f);
    }
    
    float rx;
    float ry;


    void CanRotate()
    {
        canRotate = true;
    }

    void Update()
    {
        if (!canRotate) return;

        float mx = Input.GetAxis("Mouse X"); 
        float my = Input.GetAxis("Mouse Y"); 

        rx += rotateSpeed * my * Time.deltaTime;
        ry += rotateSpeed * mx * Time.deltaTime;

        rx = Mathf.Clamp(rx, -65, 65);

        transform.eulerAngles = new Vector3(-rx, ry, 0);
    }
}
