using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 0=A
1=B
2=X
3=Y
4=L1
5=R1
6=backbutton
7=startbutton
���X�e�B�b�N������������i��������j�V�����̂ɂ������������

pad
��
pad:o,-1
��
pad:o,1
�E
pad:1,0
��
pad:-1,0
 */
public class Cat_controller : MonoBehaviour
{
    Animator animator; // �����o�ϐ�
    //private Vector3 latestPos;  //�O���Position
    //[SerializeField]
    //Transform target;
    private Rigidbody rb;
    public int speed=1;
    public float number = 100f;
    public float JumpPower = 1000f;
   
    private void pounce()
    {
        transform.Translate(0, 0, 0.5f);
        rb.AddForce(0, -1000, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    } 
    // Update is called once per frame
    void Update()
    {
       
        
        // Get the movement vector
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        
        // Normalize the movement vector
        movement.Normalize();

        if (movement != Vector3.zero)
        {
            // Calculate the rotation based on the movement vector
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            // Apply the rotation to the character's transform
            transform.rotation = targetRotation;
        }
        
        // Apply movement to the character's rigidbody
        rb.velocity = movement * speed;


        
        if (Input.GetKeyDown("joystick button 0"))//A�{�^��
        {
            //rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
        if (Input.GetKeyDown("joystick button 1"))//B�{�^��
        {
            //Debug.Log("button1");
        }
        if (Input.GetKeyDown("joystick button 2"))//X�{�^��
        {
            //Debug.Log("button2");
        }
        if (Input.GetKeyDown("joystick button 3"))//Y�{�^��
        {
            //Debug.Log("button3");
        }
        if (!Input.GetKeyDown("joystick button 4"))//L1
        {
            animator.SetFloat("L1_speed", 0);
        }
        if (Input.GetKeyDown("joystick button 4"))//L1
        {
            animator.SetFloat("L1_speed",1);
            if (Input.GetKeyDown("joystick button 4") && (Input.GetKeyDown("joystick button 0")))
            {
                animator.SetTrigger(" pounce");
                Invoke("pounce", 0.3f);
                //transform.Translate(0, 0, 1);
                /*Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbody���擾
                Vector3 force = new Vector3(0.0f, 0.0f, 1000.0f);    // �͂�ݒ�
                rb.AddForce(force);  // �͂�������*/
                //rb.AddForce(0,0,1000);  // �͂�������

                //Debug.Log("aa");
            }
            /* animator.SetBool("L1_speed",true);
Invoke("L1_speed",0.5f);*/
        }
        if (Input.GetKeyDown("joystick button 5"))//R1
        {
            //Debug.Log("button5");
        }
        if (Input.GetKeyDown("joystick button 6"))//back�{�^��
        {
            //Debug.Log("button6");
        }
        if (Input.GetKeyDown("joystick button 7"))//start�{�^��
        {
            //Debug.Log("button7");
        }
        /*
        if (Input.GetKeyDown("joystick button 8"))//�����Ȃ�
        {
            Debug.Log("button8");
        }
        if (Input.GetKeyDown("joystick button 9"))//�����Ȃ�
        {
            Debug.Log("button9");
        }
        //float hori = Input.GetAxis("Horizontal");
        //float vert = Input.GetAxis("Vertical");
        if ((hori != 0) || (vert != 0))
        {
            Debug.Log("stick:" + hori + "," + vert);
        }
        */
        //L Stick
        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");
        if ((lsh != 0) || (lsv != 0))
        {
            if (lsh == 1.0f)
            {
                animator.SetFloat("Walk_speed", 1);//�������[�V�����P
                
                if (Input.GetKeyDown("joystick button 0"))//A�{�^��
                {
                    animator.SetTrigger("Runjump");//�W�����v���[�V�����Q
                    //rb.AddForce(transform.up * number * Time.deltaTime);
                    //Debug.Log("button0");
                }
            }
            else if (lsh == -1.0f)
            {
                animator.SetFloat("Walk_speed", 1);
                
                if (Input.GetKeyDown("joystick button 0"))//A�{�^��
                {
                    animator.SetTrigger("Runjump");
                    //Debug.Log("button1");   
                }
            }
            else if (lsh > 0.5f)
            {
                animator.SetFloat("Walk_speed", 0.5f);
                
                if (Input.GetKeyDown("joystick button 0"))//A�{�^��
                {
                    transform.Translate(0, 1 * speed * Time.deltaTime, 0);
                    animator.SetTrigger("jump");
                    //Debug.Log("button2");   
                }
            }
            else if (lsh < -0.5f)
            {
                animator.SetFloat("Walk_speed", 0.5f);
                
                if (Input.GetKeyDown("joystick button 0"))//A�{�^��
                {
                    animator.SetTrigger("jump");
                    //Debug.Log("button3");   
                }
            }
            else if (lsv == 1.0f)
            {
                animator.SetFloat("Walk_speed", 1);
                
                if (Input.GetKeyDown("joystick button 0"))//A�{�^��
                {
                    animator.SetTrigger("Runjump");
                    //Debug.Log("button4");   
                }
            }
            else if (lsv == -1.0f)
            {
                animator.SetFloat("Walk_speed", 1);
                
                if (Input.GetKeyDown("joystick button 0"))//A�{�^��
                {
                    animator.SetTrigger("Runjump");
                    //Debug.Log("button5");   
                }
            }
            else if (lsv > 0.5f)
            {
                animator.SetFloat("Walk_speed", 0.5f);
                
                if (Input.GetKeyDown("joystick button 0"))//A�{�^��
                {
                    animator.SetTrigger("jump");
                    //Debug.Log("button6");   
                }
            }
            else if (lsv < -0.5f)
            {
                animator.SetFloat("Walk_speed", 0.5f);
                
                if (Input.GetKeyDown("joystick button 0"))//A�{�^��
                {
                    animator.SetTrigger("jump");
                    //Debug.Log("button7");   
                }
            }
            else
            {
                animator.SetFloat("Walk_speed", 0);
                
            }
        }


        //R Stick
        float rsh = Input.GetAxis("R_Stick_H");
        float rsv = Input.GetAxis("R_Stick_V");
        if ((rsh != 0) || (rsv != 0))
        {
            //Debug.Log("R stick:" + rsh + "," + rsv);
        }
        //D-Pad
        float dph = Input.GetAxis("D_Pad_H");
        float dpv = Input.GetAxis("D_Pad_V");
        if ((dph != 0) || (dpv != 0))
        {
            //Debug.Log("D Pad:" + dph + "," + dpv);
            
        }
        /*
        ���Pc
        ���Qb
        ���Rd
        ���Sa
          */
        if (dph == 1.0f)
        {
            //�����ۂ����
            animator.SetTrigger("swaying");
            //Debug.Log("a");
        }
        if (dph == -1.0f)
        {
            //�Њd
            animator.SetTrigger("cry");
            //Debug.Log("b");
        }
        if (dpv == 1.0f)
        {
            //��
            animator.SetTrigger("cry");
            //Debug.Log("c");
        }
        if (dpv == -1.0f)
        {
            //�Q�]��
            animator.SetTrigger("lie");
           // Debug.Log("d");
        }


        //Trigger�iL2,R2)��+-�ŕ����Ă���
        float tri = Input.GetAxis("L_R_Trigger");
        if (tri > 0)
        {
            //Debug.Log("L trigger:" + tri);
        }
        else if (tri < 0)
        {
            //Debug.Log("R trigger:" + tri);
        }
        /*
         //L2||R2�������Ă��Ȃ��Ȃ�
        else
        {
            Debug.Log("  trigger:none");
        }
        */




















        /*
        //�����A�X�y�[�X�L�[�������ꂽ��Ȃ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Bool�^�̃p�����[�^�[�ł���animator_speed��True�ɂ���
            animator.SetBool("animator_speed", true);
        }
        //�����AW��LeftShift�������ꂽ��Ȃ�
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //Float�^�̃p�����[�^�[�ł���Run_speed��1.0f����
            animator.SetFloat("Run_speed", 1.0f);
        }
        //�����AW�������ꂽ��Ȃ�
        if (Input.GetKey(KeyCode.W))
        {
            //Float�^�̃p�����[�^�[�ł���Walk_speed��1.0f����
            animator.SetFloat("Walk_speed", 1.0f );
        }

        if(Input.GetKey(KeyCode.A))
        {
            //Float�^�̃p�����[�^�[�ł���Walk_speed��1.5f����
            animator.SetFloat("Walk_speed", 1.5f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Float�^�̃p�����[�^�[�ł���Walk_speed��1.5f����
            animator.SetFloat("Walk_speed", 2.0f);
        }


        /* float a = Input.GetAxis("Horizontal");
         float w = Input.GetAxis("Vertical");
         bool fire = Input.GetButtonDown("Fire1");

         animator.SetFloat("Walk_speed", a);
         animator.SetFloat("Run_speed", w);
         animator.SetBool("Edge_speed", fire);*/
        /*float current_speed = Animator.GetFloat("Speed");

        // ���[�V�����؂�ւ���10�b�Ŋ���������
        Animator.SetFloat("Speed", current_speed + Time.deltaTime * 0.1f);*/
    }
}
