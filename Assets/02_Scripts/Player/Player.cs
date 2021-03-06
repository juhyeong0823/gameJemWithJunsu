using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static float deathCount;

    public float bulletTimeStaminaMax = 1000f;
    float bulletTimeStaminaNow = 0f;
    public float shootDistance = 50f;
    public float speed = 10f;

    Rigidbody rigid;
    Vector3 rigidVelocity;

    public Slider bulletTimeSlider;
    public Text clearText;
    public Camera cam;
    public Timer timer;

    bool isBullet = false;
    bool canClear = false;
    public static bool isDied;


    private void Start()
    {
        bulletTimeStaminaNow = bulletTimeStaminaMax;
        bulletTimeSlider.value = (float)bulletTimeStaminaNow / (float)bulletTimeStaminaMax;
        rigid = GetComponent<Rigidbody>();
        GameManager.instance.effectPlayer.clip = GameManager.instance.shootSound;
    }



    void Update()
    {
        Shoot();
        BulletTimeUse();
        BulletTime();
        AutoMove();



        if (Input.GetKeyDown(KeyCode.R))
            Re();

    }

    void AutoMove()
    {
        if(isDied)
        {
            rigid.velocity = new Vector3(0f, 0f, 0f);
        }

        if (speed < 10)
            speed += Time.deltaTime * 5f;

        rigidVelocity = rigid.velocity;

        if (rigid.velocity.z > 30)
        {
            rigid.velocity = new Vector3(rigidVelocity.x, rigidVelocity.y, 30);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }    

    void BulletTimeUse()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            bulletTimeStaminaNow -= Time.unscaledDeltaTime;
            bulletTimeSlider.value = (float)bulletTimeStaminaNow / (float)bulletTimeStaminaMax;
        }
    }

    void BulletTime()
    {
        if (bulletTimeStaminaNow <= 0){
            Time.timeScale = 1;
            isBullet = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            Time.timeScale = 0.5f;
            isBullet = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space)){
            Time.timeScale = 1f;
            isBullet = false;
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (UIManager.instance.soundSet.activeSelf ||UIManager.instance.escPanel.activeSelf ||GameManager.instance.effectPlayer.isPlaying) return;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, shootDistance)){
                if (hit.transform.CompareTag("Enemy")){
                    hit.transform.GetComponent<Enemy>().DestroyThis();
                    timer.stageEnemyCount--;
                }
            }
            GameManager.instance.effectPlayer.clip = GameManager.instance.shootSound;
            GameManager.instance.effectPlayer.Play();
        }
        if (timer.stageEnemyCount <= 0) canClear = true;
    }

    public void Re()
    {
        deathCount++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        timer.GetComponent<Timer>().timerNow = timer.GetComponent<Timer>().timer;

        UIManager.instance.escPanel.SetActive(false);
        Time.timeScale = 1;

        isDied = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Chaser"))
        {
            UIManager.instance.escPanel.SetActive(true);
            Time.timeScale = 0;
            clearText.text = "Died!";
            clearText.gameObject.SetActive(true);
            isDied = true;
        }
        else if(other.CompareTag("Clear"))
        {
            Time.timeScale = 0;
            UIManager.instance.escPanel.SetActive(true);

            if (canClear)
            {
                clearText.text = "Stage Clear!!";

                if(other.gameObject.name == "Door1")        GameManager.instance.cleardStage = 1;               
                else if (other.gameObject.name == "Door2")  GameManager.instance.cleardStage = 2;              
                else if (other.gameObject.name == "Door3")  GameManager.instance.cleardStage = 3;                
                else if (other.gameObject.name == "Door4")  GameManager.instance.cleardStage = 4;              
            }
            else
            {
                clearText.text = "???? ???? ??????????!";
            }

            clearText.gameObject.SetActive(true);
            Destroy(other.gameObject); // ?????? ?? ?????? ???? ?? ?????? ?????? ?????? ???????
        }
        else if(other.CompareTag("Death")){
            UIManager.instance.escPanel.SetActive(true);
            Time.timeScale = 0;
            clearText.text = "Died!";
            clearText.gameObject.SetActive(true);
            isDied = true;

        }



    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
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
            speed = 5f;

        }
    }
}
