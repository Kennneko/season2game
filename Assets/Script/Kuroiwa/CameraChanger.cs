using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    float Scaletime;
    bool changeSW;//falseÇ≈âEÅBtrueÇ≈ç∂ÅB
    [SerializeField] GameObject cameraObject;
    [SerializeField] GameObject rightCameraPosObj;
    [SerializeField] GameObject leftCameraPosObj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            if(changeSW == false)
            {
                cameraObject.transform.position = leftCameraPosObj.transform.position;
                changeSW = true;
            }
            else if(changeSW == true)
            {
                cameraObject.transform.position = rightCameraPosObj.transform.position;
                changeSW = false;
            }
        }
    }
}
