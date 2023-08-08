using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegacyMove : MonoBehaviour
{
    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;

    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] Camera cameraObject;
    bool jumpSW;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("Jump") && jumpSW == true)
        {
            rb.AddForce(0, 5, 0, ForceMode.Impulse);
            jumpSW = false;
        }
    }

    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(cameraObject.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + cameraObject.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(jumpSW == false)
        {
            jumpSW = true;
        }
    }
    //参考にしたサイト
    //https://tech.pjin.jp/blog/2016/11/04/unity_skill_5/
}
