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
