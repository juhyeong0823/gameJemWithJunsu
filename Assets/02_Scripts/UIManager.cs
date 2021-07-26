using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{

    #region
    private static UIManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static UIManager instance
    {
        get
        {
            if (null == Instance)
            {
                return null;
            }
            return Instance;
        }
    }
    #endregion

    public Sprite on;
    public Sprite off;

    [Header("사운드")]
    public Button soundBtn;
    public AudioMixer audioMixer;
    private float volume;

    [Header("메뉴!")]
    public Button menuOn;

    public Button soundSetBtn;
    public Button soundSetExit;
    public GameObject soundSet;
    public Button quit;

    [Header("죽었을 때 재시작 메뉴")]
    public Canvas restartPanel;

    public Button restartBtn; // 다시 시작
    public Button continueBtn; //그냥 pause 풀기
    public Button goSelectScene; // 스테이지 셀렉트 하러 가기

    bool isMenuOpened = false;
    void Start()
    {
        menuOn.onClick.AddListener(() =>
        {
            if (!isMenuOpened)
            {
                soundSetBtn.gameObject.SetActive(true);
                quit.gameObject.SetActive(true);

                isMenuOpened = true;
            }
            else
            {
                soundSetBtn.gameObject.SetActive(false);
                quit.gameObject.SetActive(false);

                isMenuOpened = false;
            }
            
        });

       quit.onClick.AddListener(() =>
       {
           print("체크");
           Application.Quit();
       });

        restartBtn.onClick.AddListener(() =>
        {
            GameManager.instance.LoadScene(GameManager.instance.GetSceneName());
        });

        continueBtn.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
        });

        goSelectScene.onClick.AddListener(() =>
        {
            GameManager.instance.LoadScene("StageSelect");
        });

        soundSetBtn.onClick.AddListener(() =>
        {
           soundSet.SetActive(true);
        });

        
        soundSetExit.onClick.AddListener(() =>
        {
            soundSet.SetActive(false);
        });


        soundBtn.onClick.AddListener(() =>
        {
            GameManager.instance.soundOn = GameManager.instance.soundOn ? false : true;
            if(GameManager.instance.soundOn)
            {
                soundBtn.GetComponent<Image>().sprite = on;
                audioMixer.SetFloat("Master", 0.75f);
            }
            else
            {
                soundBtn.GetComponent<Image>().sprite = off;
                audioMixer.SetFloat("Master", 0f);
            }
        });

        audioMixer.SetFloat("Master", 0.75f);
    }

    public void SoundSet()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject; // 방금 클릭한 오브젝트를 받아오는거
        volume = Mathf.Log10(obj.GetComponent<Slider>().value * 100f); // 클릭한거의 슬라이드 값을 받아와서 음향 조정.

        audioMixer.SetFloat(obj.name, volume);
    }

    bool isPause = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPause)
            {
                Time.timeScale = 0;
                restartPanel.enabled = true;

                isPause = true;
            }
            else
            {
                Time.timeScale = 1;
                restartPanel.enabled = false;

                isPause = false;

            }
        }
    }
}
