using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static float deathCount;
    public float speed = 10f;


    public float bulletTimeStaminaMax = 5f;
    public float bulletTimeStaminaNow = 5f;

    public Slider bulletTimeSlider;

    Rigidbody rigid;

    public ParticleSystem speedEffect;
    

    public Timer timer;

    bool isBullet = false;


    void BulletTimeUse()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            bulletTimeStaminaNow -= Time.unscaledDeltaTime;
            bulletTimeSlider.value = (float)bulletTimeStaminaNow / (float)bulletTimeStaminaMax;

           
        }
    }
    private void Start()
    {
        bulletTimeSlider.value = (float)bulletTimeStaminaNow / (float)bulletTimeStaminaMax;

        rigid = GetComponent<Rigidbody>();       
    }


    void ParticleSet()
    {
        if (isBullet)
        {
            var em = speedEffect.emission;
            em.rateOverTime = 25;
        }
        else if (speed > 20f)
        {
            speedEffect.startSpeed =100f;
            var em = speedEffect.emission;
            em.rateOverTime = 100f;

        }

    }

    Vector3 rigidVelocity;


    void BulletTime()
    {
        if (bulletTimeStaminaNow <= 0) return;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 0.5f;
            isBullet = true;
        }    
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1f;
            isBullet = false;
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
            Re();
        }
    }

    public void Re()
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
