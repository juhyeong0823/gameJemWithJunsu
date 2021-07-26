using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    public Button startBtn;
    public Button helpMessageBtn;
    public Button exitBtn;

    public GameObject helpMessage;
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
            onPanel = helpMessage;
        });
        exitBtn.onClick.AddListener(() =>
        {
            exitBtn.gameObject.SetActive(false);
            onPanel.SetActive(false);
        });
    }
}
