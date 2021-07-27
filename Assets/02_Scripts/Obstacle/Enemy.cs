using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject effect;
    public GameObject destroyEffect;


    public void DestroyThis()
    {
        Instantiate(effect, this.transform.position, Quaternion.identity);

        Instantiate(destroyEffect, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject );
    }
}
