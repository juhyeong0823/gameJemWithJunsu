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

    [Header("����")]
    public Button soundBtn;
    public AudioMixer audioMixer;
    private float volume;

    [Header("�޴�!")]
    public Canvas menuPanel;

    public Button soundSet;
    public Button rotSpeedSet;
    public Button quit;

    [Header("�׾��� �� ����� �޴�")]
    public Canvas restartPanel;

    public Button restartBtn; // �ٽ� ����
    public Button continueBtn; //�׳� pause Ǯ��
    public Button goSelectScene; // �������� ����Ʈ �Ϸ� ����


    void Start()
    {
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

        soundBtn.onClick.AddListener(() =>
        {
            GameManager.instance.soundOn = GameManager.instance.soundOn ? false : true;
            if(GameManager.instance.soundOn)
            {
                audioMixer.SetFloat("Master", 0.75f);
            }
            else
            {
                audioMixer.SetFloat("Master", 0f);
            }
        });

        audioMixer.SetFloat("Master", 0.75f);
    }

    public void SoundSet()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject; // ��� Ŭ���� ������Ʈ�� �޾ƿ��°�
        volume = Mathf.Log10(obj.GetComponent<Slider>().value * 100f); // Ŭ���Ѱ��� �����̵� ���� �޾ƿͼ� ���� ����.

        audioMixer.SetFloat(obj.name, volume);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            menuPanel.enabled = true;
        }
    }

}
