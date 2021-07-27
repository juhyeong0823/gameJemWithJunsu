using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static float deathCount;
    public float speed = 10f;
    public Camera cam;

    public float bulletTimeStaminaMax = 5f;
    public float bulletTimeStaminaNow = 5f;

    public Slider bulletTimeSlider;
    public Text clearText;


    Rigidbody rigid;

    public ParticleSystem speedEffect;


    public Timer timer;

    bool isBullet = false;
    bool canClear = false;


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


        GameManager.instance.effectPlayer.clip = GameManager.instance.shootSound;
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
        if (bulletTimeStaminaNow <= 0)
        {
            Time.timeScale = 1;
            isBullet = false;
            return;
        }

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

        Shoot();
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

    public float shootDistance = 50f;

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (UIManager.instance.soundSet.activeSelf ||
                UIManager.instance.escPanel.activeSelf ||
                 GameManager.instance.effectPlayer.isPlaying) return;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, shootDistance))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    hit.transform.GetComponent<Enemy>().DestroyThis();
                    timer.stageEnemyCount--;
                }
            }


            GameManager.instance.effectPlayer.clip = GameManager.instance.shootSound;
            GameManager.instance.effectPlayer.Play();

        }

        if (timer.stageEnemyCount <= 0)
            canClear = true;
    }

    public void Re()
    {
        deathCount++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        timer.GetComponent<Timer>().timerNow = timer.GetComponent<Timer>().timer;

        UIManager.instance.escPanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Chaser"))
        {
            UIManager.instance.escPanel.SetActive(true);
            Time.timeScale = 0;
            clearText.text = "Died!";
            clearText.gameObject.SetActive(true);

        }
        else if(other.CompareTag("Clear"))
        {
            Time.timeScale = 0;
            UIManager.instance.escPanel.SetActive(true);

            if (canClear)
            {
                clearText.text = "Stage Clear!!";
            }
            else
            {
                clearText.text = "적이 아직 남아있어요!";
            }

            clearText.gameObject.SetActive(true);

            Destroy(other.gameObject);

        }
        else if(other.CompareTag("Death"))
        {
            UIManager.instance.escPanel.SetActive(true);
            Time.timeScale = 0;
            clearText.text = "Died!";
            clearText.gameObject.SetActive(true);

        }



    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            rigid.velocity = new Vector3(rigidVelocity.x, rigidVelocity.y, 10);
            speed = 5f;
        }
        else if(col.gameObject.CompareTag("Enemy"))
        {
            UIManager.instance.escPanel.SetActive(true);
            Time.timeScale = 0;

            clearText.text = "Died!";
            clearText.gameObject.SetActive(true);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Slow"))
        {
            rigid.velocity = new Vector3(rigidVelocity.x, rigidVelocity.y, 10);
            speed = 5f;

        }
    }
}
