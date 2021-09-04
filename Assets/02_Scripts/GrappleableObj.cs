using System.Collections;
using UnityEngine;

public class GrappleableObj : MonoBehaviour
{
    private MeshRenderer mesh;

    GameObject p;
    bool canChanged = true;

    private void Start()
    {
        p = GameObject.Find("Player");
        mesh = GetComponent<MeshRenderer>();
        mesh.material.color = Color.blue;

    }

    private void Update()
    {
        if (canChanged && Mathf.Abs(Vector3.Distance(transform.position, p.transform.position)) < 40f)
        {
            Debug.LogError(Vector3.Distance(transform.position, p.transform.position));
            mesh.material = GameManager.instance.grappleableMat;
            canChanged = false;
        }
    }
}
