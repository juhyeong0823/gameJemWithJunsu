using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;
    public float timerNow;

    public Text timerText;
    public Text deathCountText;

    public Text timeOverText;

    GameObject player;

    bool isFirst = true;

    private void Awake()
    {
        player = GameObject.Find("Player");
        timerNow = timer;
    }



    private void Update()
    {
        if (!isFirst) return;

        timerNow -= Time.unscaledDeltaTime;

        timerText.text = string.Format("{0:#.##}", timerNow);

        deathCountText.text = string.Format("µµÀü È½¼ö : {0}", Player.deathCount);

        if (timerNow <= 0f)
        {
            Time.timeScale = 0;
            timerNow = 0f;

            
            UIManager.instance.escPanel.SetActive(true);

            isFirst = false;
            
        }
        
    }

}
