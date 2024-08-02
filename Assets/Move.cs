/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] Transform tr;
    [SerializeField] Rigidbody rb;

    float moveSpeed = 50f;
    float boostSpeed = 100f; // 추가된 부스트 속도
    float rotSpeed = 900f;
    float jumpForce = 35f;
    public bool isJump = false;
    [SerializeField] Animator ani;

    float h, v, r;
    float currentSpeed;

    void Start()
    {
        tr = transform;
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJump = false;
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        Vector3 moveDir = (h * Vector3.right) + (v * Vector3.forward);

        if (moveDir != Vector3.zero)
            ani.SetBool("isWalk", true);
        else
            ani.SetBool("isWalk", false);
            
        ani.SetBool("isRun", currentSpeed == boostSpeed); // 더 간결하게 작성

        tr.Translate(moveDir.normalized * currentSpeed * Time.deltaTime, Space.Self);
        tr.rotation = Quaternion.identity;


        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJump = true;
        }
    }
}
 */