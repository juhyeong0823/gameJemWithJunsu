using UnityEngine;
using UnityEngine.SceneManagement;

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


    public bool soundOn = true;

    [Header("게임 데이터들")] // 인스펙터에서 이걸로 보여줌
    public int stage = 1;


    [Header("음향")] // 인스펙터에서 이걸로 보여줌
    public float mainSound  ; // 전체음량
    public float effectSound; // 효과음
    public float bgmSound   ;   // 효과음

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
