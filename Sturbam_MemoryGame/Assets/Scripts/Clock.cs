using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    public static float timer;
    string niceTime;

    public TextMeshProUGUI CurTime;

    private void Start()
    {
        CurTime = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //increase the timer
        if (!Variables.win) {
            timer += Time.deltaTime;
        }

    }

    void OnGUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        niceTime = string.Format("{0:00}:{1:00}", minutes, seconds); //sets time format

        CurTime.text = niceTime; //sets time
    }
}
