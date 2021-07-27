using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr; // ���� �׷��ִ°Ű�

    [SerializeField]  private GameObject gun; // ���η����� �޾ƿ��� �뵵�� �������� �̴ϴ�.

    private Vector3 grapplePoint;

    public LayerMask whatIsGrappleable; // ���� �� �ִ� ���̾�
    public LayerMask whatIsGrappleable2; // �ٴ�  ���̾�

    public Transform shootPos, player; // ������ ������ ��ġ, ī�޶� ��ġ, �÷��̾� ��ġ

    public float maxDistance = 30f;
    public float damper, spring, mass;

    private SpringJoint joint;

    public Camera cam;

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
