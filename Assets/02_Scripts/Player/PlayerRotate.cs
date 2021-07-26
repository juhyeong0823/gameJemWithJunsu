using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour // 사실상 카메라가 돌아가는 겁니다.
{
    private bool canRotate = false;

    private void Awake()
    {
        Invoke("CanRotate", 1.5f);
    }

    float rx;
    float ry;

    public float rotSpeed = 500;
    public Camera cam;

    void CanRotate()
    {
        canRotate = true;
    }

    void Update()
    {
        if (!canRotate) return;

        //1. 마우스 입력 값을 이용한다.
        float mx = Input.GetAxis("Mouse X"); //게임창에서 마우스를 왼쪽 오른쪽으로 이동할때 마다 (왼 -음수 : 오른 +양수)
        float my = Input.GetAxis("Mouse Y"); //게임창에서 마우스를 왼쪽 오른쪽으로 이동할때 마다 (아래 -음수 : 위 +양수)

        rx += rotSpeed * my * Time.deltaTime;
        ry += rotSpeed * mx * Time.deltaTime;

        //rx 회전 각을 제한 (화면 밖으로 마우스가 나갔을때 x축 회전 덤블링 하듯 계속 도는 것을 방지)
        rx = Mathf.Clamp(rx, -65, 65);
        //x을 돌리는 이유 x축이 이동이 아니라 x축을 회전 해서 위아래 보는 방향은 x축이여야 한다.

        //2. 회전을 한다.
        transform.eulerAngles = new Vector3(-rx, ry, 0);
        //X축의 회전은 양수가 증가되면 아래, 음수가 증가되면 위로 돌아간다. (그래서 x축을 -를 넣었다)

    }
}
