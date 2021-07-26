using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    #region
    private static SaveManager Instance;
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

    public static SaveManager instance
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


    const string saveFileName = "saveFile.sav";


    string getFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) Save();      

        if (Input.GetKeyDown(KeyCode.L)) Load();
       
    }

    public void Save()
    {
        StreamWriter sw = new StreamWriter(getFilePath(saveFileName));

        sw.WriteLine(GameManager.instance.soundOn);
        sw.WriteLine(GameManager.instance.stage);
        sw.WriteLine(GameManager.instance.mainSound);
        sw.WriteLine(GameManager.instance.effectSound);
        sw.WriteLine(GameManager.instance.bgmSound);
        sw.Close();
    }

    public void Load()
    {
        StreamReader sr = new StreamReader(getFilePath(saveFileName));

        print(sr.ReadLine());
        print(sr.ReadLine());

        sr.Close();
    }
}
