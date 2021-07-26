using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr; // 로프 그려주는거고
    [SerializeField]
    private GameObject gun; // 라인렌더러 받아오는 용도로 만들어놓은 겁니다.
    private Vector3 grapplePoint; //  이 친구는 뭘까요?

    public LayerMask whatIsGrappleable; // 잡을 수 있는 레이어

    public Transform shootPos, cameraPos, player; // 로프가 나가는 위치, 카메라 위치, 플레이어 위치

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
        if (!joint) return; // 조인트가 없다 = 로프 커넥트가 안된거니까 그리지도 말아야 합니당
        lr.SetPosition(0, shootPos.position);
        lr.SetPosition(1, grapplePoint);
    }
}
