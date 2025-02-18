using UnityEngine;
using TMPro;

public class TimeCycle : MonoBehaviour
{
    public static bool isNight;
    public int startHour, startMinute, nightStartHour, dayStartHour, hour, minute;
    public TextMeshProUGUI timeText;
    float minuteChange;

    // Start is called before the first frame update
    void Start()
    {
        // Set the hour and minute
        hour = startHour;
        minute = startMinute;
        minuteChange = startMinute;

        ChangeHour();
        DisplayTime();
    }

    // Update is called once per frame
    void Update()
    {
        // Increase the minute every second
        minuteChange += Time.deltaTime;
        minute = Mathf.RoundToInt(minuteChange);

        ChangeHour();
        DisplayTime();
    }

    public void ChangeHour()
    {
        // Reset the minute back to 0 and increase the hour
        if(minute > 59)
        {
            hour++;

            // Cycle back to 0 if the hour hits 24
            if (hour == 24) hour = 0;

            minute = 0;
            minuteChange = 0;
        }

        // Set if it's night or day
        if (hour >= nightStartHour || hour < dayStartHour) isNight = true;
        else isNight = false;
    }

    public void DisplayTime()
    {
        // Display the time in string format
        string minuteText = $"{minute}", hourText = $"{hour}";

        // Add a 0 before the number if single digit
        if (minute < 10) minuteText = $"0{minute}";
        if (hour < 10) hourText = $"0{hour}";

        timeText.text = $"Time: {hourText}:{minuteText}";
    }
}
