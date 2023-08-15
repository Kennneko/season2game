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
左スティックだけ動かせる（反応する）新しいのにしたから消えた

pad
下
pad:o,-1
上
pad:o,1
右
pad:1,0
左
pad:-1,0
 */
public class Cat_controller : MonoBehaviour
{
    Animator animator; // メンバ変数
    //private Vector3 latestPos;  //前回のPosition
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


        
        if (Input.GetKeyDown("joystick button 0"))//Aボタン
        {
            //rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
        if (Input.GetKeyDown("joystick button 1"))//Bボタン
        {
            //Debug.Log("button1");
        }
        if (Input.GetKeyDown("joystick button 2"))//Xボタン
        {
            //Debug.Log("button2");
        }
        if (Input.GetKeyDown("joystick button 3"))//Yボタン
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
                /*Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
                Vector3 force = new Vector3(0.0f, 0.0f, 1000.0f);    // 力を設定
                rb.AddForce(force);  // 力を加える*/
                //rb.AddForce(0,0,1000);  // 力を加える

                //Debug.Log("aa");
            }
            /* animator.SetBool("L1_speed",true);
Invoke("L1_speed",0.5f);*/
        }
        if (Input.GetKeyDown("joystick button 5"))//R1
        {
            //Debug.Log("button5");
        }
        if (Input.GetKeyDown("joystick button 6"))//backボタン
        {
            //Debug.Log("button6");
        }
        if (Input.GetKeyDown("joystick button 7"))//startボタン
        {
            //Debug.Log("button7");
        }
        /*
        if (Input.GetKeyDown("joystick button 8"))//反応なし
        {
            Debug.Log("button8");
        }
        if (Input.GetKeyDown("joystick button 9"))//反応なし
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
                animator.SetFloat("Walk_speed", 1);//歩きモーション１
                
                if (Input.GetKeyDown("joystick button 0"))//Aボタン
                {
                    animator.SetTrigger("Runjump");//ジャンプモーション２
                    //rb.AddForce(transform.up * number * Time.deltaTime);
                    //Debug.Log("button0");
                }
            }
            else if (lsh == -1.0f)
            {
                animator.SetFloat("Walk_speed", 1);
                
                if (Input.GetKeyDown("joystick button 0"))//Aボタン
                {
                    animator.SetTrigger("Runjump");
                    //Debug.Log("button1");   
                }
            }
            else if (lsh > 0.5f)
            {
                animator.SetFloat("Walk_speed", 0.5f);
                
                if (Input.GetKeyDown("joystick button 0"))//Aボタン
                {
                    transform.Translate(0, 1 * speed * Time.deltaTime, 0);
                    animator.SetTrigger("jump");
                    //Debug.Log("button2");   
                }
            }
            else if (lsh < -0.5f)
            {
                animator.SetFloat("Walk_speed", 0.5f);
                
                if (Input.GetKeyDown("joystick button 0"))//Aボタン
                {
                    animator.SetTrigger("jump");
                    //Debug.Log("button3");   
                }
            }
            else if (lsv == 1.0f)
            {
                animator.SetFloat("Walk_speed", 1);
                
                if (Input.GetKeyDown("joystick button 0"))//Aボタン
                {
                    animator.SetTrigger("Runjump");
                    //Debug.Log("button4");   
                }
            }
            else if (lsv == -1.0f)
            {
                animator.SetFloat("Walk_speed", 1);
                
                if (Input.GetKeyDown("joystick button 0"))//Aボタン
                {
                    animator.SetTrigger("Runjump");
                    //Debug.Log("button5");   
                }
            }
            else if (lsv > 0.5f)
            {
                animator.SetFloat("Walk_speed", 0.5f);
                
                if (Input.GetKeyDown("joystick button 0"))//Aボタン
                {
                    animator.SetTrigger("jump");
                    //Debug.Log("button6");   
                }
            }
            else if (lsv < -0.5f)
            {
                animator.SetFloat("Walk_speed", 0.5f);
                
                if (Input.GetKeyDown("joystick button 0"))//Aボタン
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
        ↑１c
        ←２b
        ↓３d
        →４a
          */
        if (dph == 1.0f)
        {
            //しっぽゆらゆら
            animator.SetTrigger("swaying");
            //Debug.Log("a");
        }
        if (dph == -1.0f)
        {
            //威嚇
            animator.SetTrigger("cry");
            //Debug.Log("b");
        }
        if (dpv == 1.0f)
        {
            //鳴く
            animator.SetTrigger("cry");
            //Debug.Log("c");
        }
        if (dpv == -1.0f)
        {
            //寝転ぶ
            animator.SetTrigger("lie");
           // Debug.Log("d");
        }


        //Trigger（L2,R2)と+-で分けている
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
         //L2||R2を押していないなら
        else
        {
            Debug.Log("  trigger:none");
        }
        */




















        /*
        //もし、スペースキーが押されたらなら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Bool型のパラメーターであるanimator_speedをTrueにする
            animator.SetBool("animator_speed", true);
        }
        //もし、WとLeftShiftが押されたらなら
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //Float型のパラメーターであるRun_speedを1.0fする
            animator.SetFloat("Run_speed", 1.0f);
        }
        //もし、Wが押されたらなら
        if (Input.GetKey(KeyCode.W))
        {
            //Float型のパラメーターであるWalk_speedを1.0fする
            animator.SetFloat("Walk_speed", 1.0f );
        }

        if(Input.GetKey(KeyCode.A))
        {
            //Float型のパラメーターであるWalk_speedを1.5fする
            animator.SetFloat("Walk_speed", 1.5f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Float型のパラメーターであるWalk_speedを1.5fする
            animator.SetFloat("Walk_speed", 2.0f);
        }


        /* float a = Input.GetAxis("Horizontal");
         float w = Input.GetAxis("Vertical");
         bool fire = Input.GetButtonDown("Fire1");

         animator.SetFloat("Walk_speed", a);
         animator.SetFloat("Run_speed", w);
         animator.SetBool("Edge_speed", fire);*/
        /*float current_speed = Animator.GetFloat("Speed");

        // モーション切り替えを10秒で完結させる
        Animator.SetFloat("Speed", current_speed + Time.deltaTime * 0.1f);*/
    }
}
