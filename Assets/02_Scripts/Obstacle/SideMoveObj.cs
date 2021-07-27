using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMoveObj : MonoBehaviour
{
    public float speed = 1;

    bool moveDir = true;

    public float time = 3f;

    private void Update()
    {
        if(moveDir)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        time -= Time.deltaTime;

        if(time <= 0)
        {
            if(moveDir)
            {
                moveDir = !moveDir;
            }
            else
            {
                moveDir = true;
            }
            time = 3f;
        }
    }
}
