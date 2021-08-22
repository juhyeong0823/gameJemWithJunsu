using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelecter : MonoBehaviour
{
    public Button[] stageBtns;
    public GameObject[] lockPanel;
    public GameObject[] clearCheck;

    public void ExplainOn(GameObject on)
    {
        on.SetActive(true);
    }

    public void ExplainOff(GameObject on)
    {
        on.SetActive(false);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        for (int i = 0; i < GameManager.instance.cleardStage; i++)
        {
            if (i >= 3) break;

            lockPanel[i].SetActive(false);
        }

        for (int i = 0; i < GameManager.instance.cleardStage; i++)
        {

            clearCheck[i].SetActive(true);
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        



        stageBtns[0].onClick.AddListener(() =>
        {
            GameManager.instance.LoadScene("Stage1");
            UIManager.instance.menuOn.gameObject.SetActive(false);
        });

        stageBtns[1].onClick.AddListener(() =>
        {
            GameManager.instance.LoadScene("Stage2");
            UIManager.instance.menuOn.gameObject.SetActive(false);

        });

        stageBtns[2].onClick.AddListener(() =>
        {
            GameManager.instance.LoadScene("Stage3");
            UIManager.instance.menuOn.gameObject.SetActive(false);

        });

        stageBtns[3].onClick.AddListener(() =>
        {
            GameManager.instance.LoadScene("Stage4");
            UIManager.instance.menuOn.gameObject.SetActive(false);

        });
    }

    void Update()
    {
        
    }


}
