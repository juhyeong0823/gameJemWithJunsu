using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr; // ���� �׷��ִ°Ű�
    [SerializeField]
    private GameObject gun; // ���η����� �޾ƿ��� �뵵�� �������� �̴ϴ�.
    private Vector3 grapplePoint; //  �� ģ���� �����?

    public LayerMask whatIsGrappleable; // ���� �� �ִ� ���̾�

    public Transform shootPos, cameraPos, player; // ������ ������ ��ġ, ī�޶� ��ġ, �÷��̾� ��ġ

    public float maxDistance = 100f;

    private SpringJoint joint;


    public Camera cam;

    public float damper, spring, mass;

    Ray ray;

    private void Awake()
    {
        lr = gun.GetComponent<LineRenderer>();
    }

    void Update()
    {
        Grap();
    }

    private void LateUpdate()
    {
        DrawRope(ray);
    }
    void Grap()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
    }


    void StartGrapple()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);


        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, whatIsGrappleable))
        {

            grapplePoint = hit.transform.position;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceToPoint = Vector3.Distance(grapplePoint, shootPos.position);

            joint.maxDistance = distanceToPoint * 0.8f;
            joint.maxDistance = distanceToPoint * 0.25f;

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
