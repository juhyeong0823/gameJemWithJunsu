using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float moveX, moveZ;
    public float speed;
    public float runSpeed;

    Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        rigid.velocity = new Vector3(moveX, 0, moveZ) * speed;
    }


}
