using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScheduleTask : MonoBehaviour
{
    public Text taskText;

    public TaskMessageScript task;

    float realTimer;�@//���A������
    int timer = 30;   //1����
    int gameTimer;    //csv�̐��l

    float longHand; //���j
    int hourHand;   //�Z�j

    public Text textUI;
    public Text timerUI;

    TextAsset csvFile;
    List<string[]> csvDatas = new List<string[]>();

    public List<string> taskLog = new List<string>();
    void Start()
    {
        realTimer = 0;
        gameTimer = -1;
        hourHand = 7;

        csvFile = Resources.Load("CSVs/ScheduleTask") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }
    }
    void Update()
    {
        taskText.text = string.Join("\n" ,taskLog);

        realTimer += 1 * Time.deltaTime;
        longHand += 1 * Time.deltaTime * 2;
        timerUI.text =  hourHand + "�F" + longHand.ToString("00"); 
        if((int)realTimer == timer)
        {
            longHand = 0;
            hourHand ++;

            realTimer = 0;
            gameTimer ++;

            task.TaskMes(true, csvDatas[gameTimer][1]);
            taskLog.Add(csvDatas[gameTimer][1]);
            StartCoroutine(FailureTask());
            //textUI.text = csvDatas[gameTimer][0] + "�F" + csvDatas[gameTimer][1] + "�F" + csvDatas[gameTimer][2];
        }

        if (Input.GetButtonDown("Fire1"))
        {
            RemoveList(true,0);
        }
    }
    public void RemoveList(bool remove , int taskNum)
    {
        if (remove)
        {
            taskLog.RemoveAt(taskNum);
        }
    }
    IEnumerator FailureTask()
    {
        yield return new WaitForSeconds(120);

        if (taskLog.Count > 4)
        {
            taskLog.RemoveAt(0);

        }
    }
}
