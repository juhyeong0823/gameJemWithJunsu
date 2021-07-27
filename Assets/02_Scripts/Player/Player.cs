using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    Vector3 rigidVelocity;

    void Update()
    {
        rigidVelocity = rigid.velocity;

        if (rigid.velocity.z > 30)
        {
            rigid.velocity = new Vector3(rigidVelocity.x, rigidVelocity.y, 30);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(speed < 10)
        {
            speed += Time.deltaTime * 5f;
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
   
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Slow"))
        {
            speed = speed % 2;
        }
        else if(col.gameObject.CompareTag("Chaser"))
        {
            UIManager.instance.escPanel.SetActive(true);
        }
    }
}
