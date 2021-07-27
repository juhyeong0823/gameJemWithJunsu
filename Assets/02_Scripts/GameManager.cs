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
    WaitForSeconds changeDelay = new WaitForSeconds(0.9f);

    private void Start()
    {


        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        while(true)
        {
            yield return changeDelay;
            neonMat.SetColor("_EmissionColor", new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0,0.5f)));
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
