using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float timer;

    public Text timerText;
    
    private void Update()
    {
        timer -= Time.deltaTime;

        timerText.text = string.Format("{0:#.##}", timer);

        if (timer <=0f)
        {
            UIManager.instance.escPanel.gameObject.SetActive(true);
        }
    }

}
