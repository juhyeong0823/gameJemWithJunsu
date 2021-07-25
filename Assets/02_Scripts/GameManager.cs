using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [HideInInspector] public UIManager uiManager = new UIManager();
    [HideInInspector] public SaveManager saveManager = new SaveManager();


    private void Start()
    {
        saveManager.Save();
    }

    public bool soundOn = true;

    [Header("���� �����͵�")] // �ν����Ϳ��� �̰ɷ� ������
    public int stage = 1;


    [Header("����")] // �ν����Ϳ��� �̰ɷ� ������
    public float mainSound; // ��ü����
    public float effectSound; // ȿ����
    public float bgmSound; // ȿ����


}
