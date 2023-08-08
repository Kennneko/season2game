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
        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        Vector3 cameraForward = Vector3.Scale(cameraObject.transform.forward, new Vector3(1, 0, 1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 moveForward = cameraForward * inputVertical + cameraObject.transform.right * inputHorizontal;

        // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        // �L�����N�^�[�̌�����i�s������
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
    //�Q�l�ɂ����T�C�g
    //https://tech.pjin.jp/blog/2016/11/04/unity_skill_5/
}
