using UnityEngine;
using UnityEngine.UI;
public class StageSelecter : MonoBehaviour
{
    public Button[] stageBtns; 
    
    void Start()
    {

        stageBtns[0].onClick.AddListener(() =>
        {
            GameManager.instance.LoadScene("Stage1");
        });

        stageBtns[1].onClick.AddListener(() =>
        {
            GameManager.instance.LoadScene("Stage2");
        });

        stageBtns[2].onClick.AddListener(() =>
        {
            GameManager.instance.LoadScene("Stage3");
        });

        stageBtns[3].onClick.AddListener(() =>
        {
            GameManager.instance.LoadScene("Stage4");
        });

        stageBtns[4].onClick.AddListener(() =>
        {
            GameManager.instance.LoadScene("Stage5");
        });
    }

    void Update()
    {
        
    }


}
