using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserScript : MonoBehaviour
{
    public float speed = 10f;


    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        speed += Time.deltaTime * 3f;
    }
}
