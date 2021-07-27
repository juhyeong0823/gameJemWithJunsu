using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 2f;

    bool startMove = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            startMove = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        speed = 0f;
    }

    void Update()
    {
        if(startMove)
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
