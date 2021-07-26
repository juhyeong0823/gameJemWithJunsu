using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleableObj : MonoBehaviour
{
    private MeshRenderer mesh;


    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))       
            mesh.material.color = Color.blue;        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            mesh.material.color = Color.red;        
    }
}
