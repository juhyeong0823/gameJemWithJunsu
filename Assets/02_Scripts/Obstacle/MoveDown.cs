using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 2f;
    bool startMove = false;


    [Header("������ �Ÿ�")]
    public float interDistance = 30f;
    GameObject player;
    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if (Mathf.Abs((player.transform.position.z - this.transform.position.z)) < interDistance)
        {
            startMove = true;
        }

        if (startMove)
            transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

}
