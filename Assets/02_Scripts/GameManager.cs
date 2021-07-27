using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{


    #region
    private static GameManager Instance;
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

    public static GameManager instance
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

    public Material neonMat;

    public AudioSource bgmPlayer;
    public AudioSource effectPlayer;

    public AudioClip playBgm; 
    public AudioClip robbyBgm;

    public AudioClip ropeSound;
    public AudioClip shootSound;


    float changeDelay = 1f;

    private void Start()
    {
        StartCoroutine(ChangeColor());
    }
    
    IEnumerator ChangeColor()
    {
        while(true)
        {
            Color targetColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 0.5f));

            float t = 0;
            while(true)
            {
                Color c = Color.Lerp(neonMat.GetColor("_EmissionColor"), targetColor, Time.deltaTime * changeDelay);
                neonMat.SetColor("_EmissionColor", c);
                yield return null;

                t += Time.deltaTime;

                if (t >= changeDelay) break;
            }
        }
    }

    public bool isPlaying = false;

    public bool soundOn = true;

    [Header("���� �����͵�")] // �ν����Ϳ��� �̰ɷ� ������
    public int stage = 1;


    [Header("����")] // �ν����Ϳ��� �̰ɷ� ������
    public float mainSound  ; // ��ü����
    public float effectSound; // ȿ����
    public float bgmSound   ;   // ȿ����

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    
}
