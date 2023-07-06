using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LongHandScript : MonoBehaviour
{
    public GameObject LongHandObject;
    public float LongHandCount = 30;
    int Seconds;
    void Start()
    {

    }

    void Update()
    {
        LongHandMove();
    }

    void LongHandMove()
    {
        LongHandCount -= Time.deltaTime;
        Seconds = (int)LongHandCount;

        LongHandObject.transform.eulerAngles = new Vector3(0, 0, 360 / 30 * LongHandCount);
        if(LongHandCount <= 0)
        {
            LongHandCount = 30;
            Debug.Log("‚ÌƒJƒEƒ“ƒg‚ª–ß‚è‚Ü‚µ‚½‚¼");
        }


        //int s = DateTime.Now.Second;
        //LongHandObject.transform.eulerAngles = new Vector3(0, 0, -360 / 60 * s);
    }
}
