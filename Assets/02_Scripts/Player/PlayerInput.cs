using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerInput : MonoBehaviour
{
    private float moveX, moveZ;
    public float speed;
    public float runSpeed;

    Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Map2");
        }
    }


    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Spring"))
        {
            rigid.AddForce(Vector3.up * 10f);
        }
    }


}
