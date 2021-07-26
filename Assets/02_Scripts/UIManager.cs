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
        GameObject obj = EventSystem.current.currentSelectedGameObject; // ��� Ŭ���� ������Ʈ�� �޾ƿ��°�
        volume = Mathf.Log10(obj.GetComponent<Slider>().value * 100f); // Ŭ���Ѱ��� �����̵� ���� �޾ƿͼ� ���� ����.

        audioMixer.SetFloat(obj.name, volume);
    }

}
