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

    public GameObject helpMessage;
    public GameObject setting;
    public GameObject exit;

    private GameObject onPanel;

    void Start()
    {
        startBtn.onClick.AddListener(() =>
        {
            GameManager.instance.LoadScene("StageSelect");
        });

        helpMessageBtn.onClick.AddListener(() =>
        {
            helpMessage.SetActive(true);
            exit = helpMessage;
        });

        settingBtn.onClick.AddListener(() =>
        {
            setting.SetActive(true);
            exit.SetActive(true);
            onPanel = setting;
        });

        exitBtn.onClick.AddListener(() =>
        {
            exit.SetActive(false);
            onPanel.SetActive(false);
        });


    }


}
