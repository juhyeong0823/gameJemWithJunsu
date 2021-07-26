using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
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
        sw.WriteLine(GameManager.instance.rotSpeed);
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
