using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLeft : MonoBehaviour
{
    public float speed = 2f;
    bool startMove = false;


    [Header("반응할 거리")]
    public float interDistance = 30f;
    [SerializeField]
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(Mathf.Abs((this.transform.position.z - player.transform.position.z)) < interDistance)
        {
            startMove = true;
            this.GetComponent<MeshRenderer>().material = GameManager.instance.changeMat;

        }
        if (startMove)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }


}
