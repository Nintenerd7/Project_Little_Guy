using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTime : MonoBehaviour
{

    public TMP_Text currentTimeText;
    public DateTime currentTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      currentTime = DateTime.Now;
      int hour = currentTime.Hour;
      int minute = currentTime.Minute;
      currentTimeText.text = hour.ToString("00") + ":" + minute.ToString("00");
    }
}
