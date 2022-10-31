using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Highscore : MonoBehaviour
{
    public TMP_Text WinText;
    TextKeeper textUpdate;
    float highTime = 99999;
    float minutes;
    float seconds;
    // Start is called before the first frame update
    void Start()
    {
        textUpdate = GameObject.Find("CameraController").GetComponent<TextKeeper>();

        if (textUpdate.bestTime1 + textUpdate.bestTime2 + textUpdate.bestTime3 + textUpdate.bestTime4 < highTime)
        {
            highTime = textUpdate.bestTime1 + textUpdate.bestTime2 + textUpdate.bestTime3 + textUpdate.bestTime4;
        }
        minutes = Mathf.FloorToInt(highTime / 60);
        seconds = Mathf.FloorToInt(highTime % 60);
        if (seconds < 10)
        {
            WinText.text = "You win!(So far)            Total Time:" + minutes + ":0" + seconds;
        }
        else
        {
            WinText.text = "You win!(So far)            Total Time:" + minutes + ":" + seconds;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
