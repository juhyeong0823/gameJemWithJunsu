using UnityEngine;

public class GrappleableObj : MonoBehaviour
{
    private MeshRenderer mesh;
    GameObject p;

    private void Awake()
    {
        p = GameObject.Find("Player");
        mesh = GetComponent<MeshRenderer>();
        mesh.material.color = Color.blue;

    }

    private void Update()
    {
        
        if(Mathf.Abs(Vector3.Distance(p.transform.position, this.transform.position)) < 40f)
        {
            mesh.material.color = new Color(0, 44, 255, 1);
        }
        else
        {
            mesh.material.color = new Color(0, 44, 255, 0.3f);
        }
    }



}
