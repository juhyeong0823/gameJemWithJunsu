using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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

    [Header("����")]
    public Button soundBtn;
    public AudioMixer audioMixer;
    private float volume;

    [Header("�޴�!")]
    public Button menuOn;

    public Button soundSetBtn;
    public Button soundSetExit;
    public GameObject soundSet;


    [Header("�޴�")]

    public GameObject escPanel;
    public Button restart;

    public Button goSelectScene; // �������� ����Ʈ �Ϸ� ����
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
           player.GetComponent<Player>().Re();

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
            Time.timeScale = 1;
            GameManager.instance.LoadScene("StageSelect");
            escPanel.SetActive(false);
            Player.deathCount = 0;

            menuOn.gameObject.SetActive(true);
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
            if (GameManager.instance.soundOn)
            {
                soundBtn.GetComponent<Image>().sprite = off;
                GameManager.instance.bgmPlayer.Pause();
                GameManager.instance.effectPlayer.enabled = false;
            }
            else
            {
                soundBtn.GetComponent<Image>().sprite = on;
                GameManager.instance.bgmPlayer.UnPause();
                GameManager.instance.effectPlayer.enabled = true;
            }

            GameManager.instance.soundOn = GameManager.instance.soundOn ? false : true;


        });

        audioMixer.SetFloat("Master", 0.75f);
    }

    public void SoundSet()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject; // ��� Ŭ���� ������Ʈ�� �޾ƿ��°�
        volume = obj.GetComponent<Slider>().value; // Ŭ���Ѱ��� �����̵� ���� �޾ƿͼ� ���� ����.

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
