using UnityEngine;

public class ChaserScript : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }
}
