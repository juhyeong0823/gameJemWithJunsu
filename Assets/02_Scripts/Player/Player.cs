using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float speed = 10f;
    public int deathCount;

    public Transform spawn;

    Rigidbody rigid;

    public Timer timer;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        
    }


    Vector3 rigidVelocity;

    void BulletTime()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 0.5f;
        }    
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1f;
        }
    }

    void Update()
    {
        BulletTime();
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
            Re(spawn);
        }
    }
   
    public void Re(Transform returnPos)
    {
        deathCount++;

        this.transform.position = spawn.position;
        timer.GetComponent<Timer>().timerNow = timer.GetComponent<Timer>().timer;
        Time.timeScale = 1;

        this.transform.localEulerAngles = new Vector3(0, 0, 0);

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Chaser"))
        {
            Debug.Log("��");

            UIManager.instance.escPanel.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Slow"))
        {
            speed = 3f;
        }
    }
}
