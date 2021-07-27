using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLeft : MonoBehaviour
{
    public float speed = 2f;
    bool startMove = false;


    [Header("반응할 거리")]
    public float interDistance = 30f;
    GameObject player;
    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if(Mathf.Abs((player.transform.position.z - this.transform.position.z)) < interDistance)
        {
            startMove = true;
            this.GetComponent<MeshRenderer>().material = GameManager.instance.changeMat;
        }

        if (startMove)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }


}
