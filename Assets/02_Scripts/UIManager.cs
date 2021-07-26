using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public Button soundBtn; 

    public AudioMixer audioMixer;
    private float volume;


    void Start()
    {
        soundBtn.onClick.AddListener(() =>{
            GameManager.instance.soundOn = GameManager.instance.soundOn ? false : true;
        });

        audioMixer.SetFloat("Master", 0.75f);
    }

    public void SoundSet()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject; // 방금 클릭한 오브젝트를 받아오는거
        volume = Mathf.Log10(obj.GetComponent<Slider>().value * 100f); // 클릭한거의 슬라이드 값을 받아와서 음향 조정.

        audioMixer.SetFloat(obj.name, volume);
    }

}
