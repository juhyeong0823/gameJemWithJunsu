using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInput : MonoBehaviour
{
    public Transform drawCirclePosition;

    private Vector3 movedir;
    private Vector3 rayDir = new Vector3(0, -1, 0);

    private bool isJumping;

    public float rayDistance;
    private float moveX, moveZ;
    public float speed;
    public float runSpeed;



    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        moveZ = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        RaycastHit hit;

        isJumping = Physics.Raycast(transform.position, rayDir * rayDistance, out hit);
        Debug.DrawRay(transform.position, rayDir * rayDistance, Color.blue);
    }

    private void move()
    {

    }
}
