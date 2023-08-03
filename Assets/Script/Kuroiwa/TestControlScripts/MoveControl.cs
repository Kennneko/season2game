using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;

    [SerializeField] float moveSpeed = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveSpeed*inputHorizontal, rb.velocity.y, moveSpeed*inputVertical);

    }
    //参考にしたサイト
    //https://tech.pjin.jp/blog/2016/11/04/unity_skill_5/
}
