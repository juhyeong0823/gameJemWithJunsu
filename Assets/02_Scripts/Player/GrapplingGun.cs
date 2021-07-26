using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr; // ���� �׷��ִ°Ű�
    [SerializeField]
    private GameObject gun; // ���η����� �޾ƿ��� �뵵�� �������� �̴ϴ�.

    private Vector3 grapplePoint;

    public LayerMask whatIsGrappleable; // ���� �� �ִ� ���̾�
    public LayerMask whatIsGrappleable2; // �ٴ�  ���̾�

    public Transform shootPos, cameraPos, player; // ������ ������ ��ġ, ī�޶� ��ġ, �÷��̾� ��ġ

    public float maxDistance = 30f;

    private SpringJoint joint;


    public Camera cam;

    public float damper, spring, mass;

    Ray ray;

    Vector3 destination;
    bool isMove;

    private void Awake()
    {
        lr = gun.GetComponent<LineRenderer>();
    }

    private void SetDestination(Vector3 dest) 
    { 
        destination = dest;
        isMove = true;
    }

    private void Move()
    {
        if (isMove) 
        { 
            if (Vector3.Distance(destination, transform.parent.transform.position) <= 0.1f)
            {
                isMove = false; 
                return; 
            }
            var dir = destination - transform.parent.transform.position;
            dir.y = 0;
            transform.parent.transform.position += dir.normalized * Time.deltaTime * 5f;
        } 
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        { 
            RaycastHit hit; 
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, whatIsGrappleable2))
            {
                SetDestination(hit.point);
            } 
        }
        Move();

        Grap();
    }

    private void LateUpdate()
    {
        DrawRope(ray);
    }



    void Grap()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            StopGrapple();
        }
    }

    void StartGrapple()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;

            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceToPoint = Vector3.Distance(grapplePoint, shootPos.position);

            joint.maxDistance = distanceToPoint * 0.8f;
            joint.maxDistance = distanceToPoint * 0.4f;

            lr.positionCount = 2;
        }
    }

    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    void DrawRope(Ray _ray)
    {
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
        if (!joint) return; // ����Ʈ�� ���� = ���� Ŀ��Ʈ�� �ȵȰŴϱ� �׸����� ���ƾ� �մϴ�
        lr.SetPosition(0, shootPos.position);
        lr.SetPosition(1, grapplePoint);
    }
}
