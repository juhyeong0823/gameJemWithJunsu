using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRight : MonoBehaviour
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

    void Update()
    {
        if (startMove)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

}
