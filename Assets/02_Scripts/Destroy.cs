using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float delay = 1f;

    void Update()
    {
        Destroy(this.gameObject, delay);
    }
}
