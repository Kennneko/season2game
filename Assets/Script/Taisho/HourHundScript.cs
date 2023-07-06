using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HourHundScript : MonoBehaviour
{
    public GameObject HourHandObject;
    public float HourHandCount = 30;
    int Seconds;


    float rotationZ = 1;
    void Start()
    {
        
    }

    void Update()
    {

        HourHandObject.transform.eulerAngles -= new Vector3(0, 0, rotationZ) * Time.deltaTime;
        
    }

    void HourHandMove()
    {
        //HourHandCount -= Time.deltaTime;
        //Seconds = (int)HourHandCount;

        

        /*if (HourHandCount <= 0)
        {
            HourHandCount = 30;
            Debug.Log("’Zj‚ÌƒJƒEƒ“ƒg‚ª–ß‚è‚Ü‚µ‚½‚¼");
        }*/


        //int s = DateTime.Now.Second;
        //LongHandObject.transform.eulerAngles = new Vector3(0, 0, -360 / 60 * s);
    }
}
