using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform camTr;
    [SerializeField] Transform target;
    [SerializeField] private float h = 10f;    //카메라 높이
    [SerializeField] private float distance = 10f;    //target과의 거리
    [SerializeField] private float movedamping = 10f;   //카메라가 이동 회전시 떨림을 부드럽게 완화하도록 값 지정
    [SerializeField] private float rotdamping = 15f;
    [SerializeField] private float targetOffset = 2.0f; //target에서의 카메라 높이값


    void Start()
    {

        camTr = transform;
    }
    void Update()
    {
        if (target == null) return;

    }
    void LateUpdate()
    {
        if (target == null) return;
        var camPos = target.position/*target 포지션에서*/ - (target.forward * distance)/*distance만큼 뒤에 있고*/ + (target.up * h);/*위에 있음*/
        camTr.position = Vector3.Slerp(transform.position, camPos, Time.deltaTime * movedamping);
        camTr.rotation = Quaternion.Slerp(camTr.rotation, target.rotation, Time.deltaTime * rotdamping);
        camTr.LookAt(target.position + (target.up * targetOffset)); //target position에서 targetOffset(2)만큼 올림
    }
}
