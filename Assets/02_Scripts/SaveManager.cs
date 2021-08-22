using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    const string saveFileName = "saveFile.sav";

    string getFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }


    public void Save()
    {
        StreamWriter sw = new StreamWriter(getFilePath(saveFileName));

        sw.WriteLine(GameManager.instance.cleardStage);
        sw.Close();
    }

    public void Load()
    {
        StreamReader sr = new StreamReader(getFilePath(saveFileName));

        string stageString = sr.ReadLine();
        if (stageString == null)
        {
            sr.Close();

            return;
        }
        GameManager.instance.cleardStage = int.Parse(stageString);
        sr.Close();

    }
}
