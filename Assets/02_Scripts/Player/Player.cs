using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;

    public float acceleration; //°¡¼Óµµ

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        speed += Time.deltaTime;


        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Map2");
        }
    }
   
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Death"))
        {   
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
