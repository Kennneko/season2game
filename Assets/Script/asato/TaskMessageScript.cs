using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskMessageScript : MonoBehaviour
{
    public CanvasGroup CG;
    public AudioSource AS;
    public Text StartTex;
    public Text CompTex;
    public Text taskTxt;
    public float popSpeed;
    public float waitTime;
    AudioClip popAC;
    AudioClip compAC;
    void Awake()
    {
        CG.alpha = 0;
        popAC = Resources.Load<AudioClip>("Sounds/SE/taskPOP");
        compAC = Resources.Load<AudioClip>("Sounds/SE/taskCOMP");
        StartTex.enabled = false;
        CompTex.enabled = false;
    }


    void Update()
    {

    }

    public void TaskMes(bool isComplete, string taskWord)
    {
        taskTxt.text = taskWord;
        if (!isComplete)
        {
            CompTex.enabled = true;
            AS.PlayOneShot(compAC);
        }
        else
        {
            StartTex.enabled = false;
            AS.PlayOneShot(popAC);
        }
        StartCoroutine("fadeIn");
    }
    IEnumerator fadeIn()
    {
        float txtAlpha = 0;
        while (txtAlpha < 1)
        {
            CG.alpha = txtAlpha;
            txtAlpha += popSpeed;
            yield return new WaitForSeconds(1 / 60);
        }
        CG.alpha = 1;
        yield return new WaitForSeconds(waitTime);
        StartCoroutine("fadeOut");
    }
    IEnumerator fadeOut()
    {        float txtAlpha = 1;
        while (txtAlpha > 0)
        {
            CG.alpha = txtAlpha;
            txtAlpha -= popSpeed/2;
            yield return new WaitForSeconds(1 / 60);
        }
        CG.alpha = 0;
    }
}
