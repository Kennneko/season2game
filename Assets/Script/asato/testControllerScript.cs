using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testControllerScript : MonoBehaviour
{
    public TaskMessageScript TM;
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) TM.TaskMes(false, "test");
    }
}
