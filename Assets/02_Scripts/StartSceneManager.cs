using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    public Button startBtn;
    public Button helpMessageBtn;
    public Button settingBtn;
    public Button exitBtn;

    void Start()
    {
       startBtn.onClick.AddListener(() =>
       {
           GameManager.instance.LoadScene("StageSelect");
       });

        startBtn.onClick.AddListener(() =>
        {
            GameManager.instance.LoadScene("StageSelect");
        });


    }

    
}
