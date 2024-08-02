using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunMove : MonoBehaviour
{

    [SerializeField] Transform tr;
    [SerializeField] Rigidbody rb;
    [SerializeField] CapsuleCollider col;

    float moveSpeed = 12f;
    float jumpForce = 150f;
    //public bool isJump = false;
    public bool isBand = false;
    [SerializeField] Animator ani;
    [SerializeField] float rotSpeed = 5f;

    float h, v, r;

    void Start()
    {
        tr = transform;
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider>();

        ani.SetBool("isRun", true);
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = 1.0f;
        r = Input.GetAxis("Mouse X");

        Vector3 moveDir = (h * Vector3.right) + (v * Vector3.forward);

        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);

        tr.Rotate(Vector3.up * r * Time.deltaTime * rotSpeed);

        Jump();
        Crouch();
    }

    private void Crouch()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            ani.SetBool("isBand", true);
            col.height = 0.8f;
        }

        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            ani.SetBool("isBand", false);
            col.height = 1.6f;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetTrigger("Jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
