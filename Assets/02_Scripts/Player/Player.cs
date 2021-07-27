using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static float deathCount;
    public float speed = 10f;

    public Transform spawn;

    public float bulletTimeStaminaMax;
    public float bulletTimeStaminaNow;

    public Slider bulletTimeSlider;

    Rigidbody rigid;

    public ParticleSystem speedEffect;
    

    public Timer timer;

    void BulletTimeUse()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            bulletTimeStaminaNow -= Time.unscaledDeltaTime;
            bulletTimeSlider.value = (float)bulletTimeStaminaMax / (float)bulletTimeStaminaNow;
        }
    }
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        var em = speedEffect.emission;
        em.rateOverTime = 10f; 
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
        BulletTimeUse();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        timer.GetComponent<Timer>().timerNow = timer.GetComponent<Timer>().timer;
        Time.timeScale = 1;


    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Chaser"))
        {
            UIManager.instance.escPanel.SetActive(true);
        }
        else if(other.CompareTag("Obstacle"))
        {
            speed = 3f;
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
