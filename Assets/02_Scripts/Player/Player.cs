using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(speed < 15)
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
            UIManager.instance.restartPanel.enabled = true;
        }
    }
}
