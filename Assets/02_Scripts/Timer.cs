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

    public float stageEnemyCount;


    private void Awake()
    {
        player = GameObject.Find("Player");
        timerNow = timer;
        timeOverText.gameObject.SetActive(false);
    }



    private void Update()
    {
        timerText.text = string.Format("{0:#.##}", timerNow);
        deathCountText.text = string.Format("µµÀü È½¼ö : {0}", Player.deathCount);

        if (!isFirst) return;

        timerNow -= Time.unscaledDeltaTime;

        if (timerNow <= 0f)
        {
            Time.timeScale = 0;
            timerNow = 0f;         
            UIManager.instance.escPanel.SetActive(true);
            timeOverText.gameObject.SetActive(true);

            isFirst = false;
            
        }
        
    }

}
