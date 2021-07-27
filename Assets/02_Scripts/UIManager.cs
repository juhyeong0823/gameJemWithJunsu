using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

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


    [Header("메뉴")]

    public GameObject escPanel;
    public Button restart;

    public Button goSelectScene; // 스테이지 셀렉트 하러 가기
    public Button quit;

    public GameObject player;

    bool isMenuOpened = false;


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.Find("Player");
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
       restart.onClick.AddListener(() =>
       {
           if(!player)
           {
               return;
           }
           escPanel.SetActive(false);
           player.GetComponent<Player>().Re(player.GetComponent<Player>().spawn);
       });

        menuOn.onClick.AddListener(() =>
        {
            if (!isMenuOpened)
            {
                soundSetBtn.gameObject.SetActive(true);
                isMenuOpened = true;
            }
            else
            {
                soundSetBtn.gameObject.SetActive(false);
                isMenuOpened = false;
            }
            
        });

        quit.onClick.AddListener(() =>
        {
            escPanel.SetActive(false);

            Application.Quit();
        });

        goSelectScene.onClick.AddListener(() =>
        {
            escPanel.SetActive(false);
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

    bool escPanelOn = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!escPanelOn)
            {
                escPanel.SetActive(true);

                escPanelOn = true;
            }
            else
            {
                escPanel.SetActive(false);

                escPanelOn = false;

            }
        }
    }
}
