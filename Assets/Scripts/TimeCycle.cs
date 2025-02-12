using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCycle : MonoBehaviour
{
    public int startHour, startMinute;
    public TextMeshProUGUI timeText;
    int hour, minute;
    float minuteChange;

    // Start is called before the first frame update
    void Start()
    {
        hour = startHour;
        minute = startMinute;
        minuteChange = startMinute;
        ChangeHour();
        DisplayTime();
    }

    // Update is called once per frame
    void Update()
    {
        minuteChange += Time.deltaTime;
        minute = Mathf.RoundToInt(minuteChange);
        ChangeHour();
        DisplayTime();
    }

    public void ChangeHour()
    {
        if(minute > 59)
        {
            hour++;
            if (hour == 24) hour = 0;
            minute -= 59;
            minuteChange = 0;
        }
    }

    public void DisplayTime()
    {
        string minuteText = $"{minute}", hourText = $"{hour}";
        if (minute < 10) minuteText = $"0{minute}";
        if (hour < 10) hourText = $"0{hour}";
        timeText.text = $"Time: {hourText}:{minuteText}";
    }
}
