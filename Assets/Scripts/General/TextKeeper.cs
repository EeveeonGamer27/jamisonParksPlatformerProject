using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextKeeper : MonoBehaviour
{
    public static TextKeeper Instance;

    public float bestTime1 = 999;
    public float bestTime2 = 999;
    public float bestTime3 = 999;
    public float bestTime4 = 999;
    public float bestTime5 = 999;
    float bestTime6 = 999;
    float bestTime7 = 999;
    float bestTime8 = 999;
    float bestTime = 99999;
    float timerTime;
    float minutes;
    float seconds;
    public TMP_Text TimerBox;
    public TMP_Text LevelBox;
    public TMP_Text Death;
    public TMP_Text Death2;
    GameController controller;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        if (Death.gameObject != null)
        {
            Death.gameObject.SetActive(false);
            Death2.gameObject.SetActive(false);
        }
        Invoke("LevelUpdate", .01f);
        controller = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerBox.gameObject != null)
        {
            timerTime += Time.deltaTime;
            minutes = Mathf.FloorToInt(timerTime / 60);
            seconds = Mathf.FloorToInt(timerTime % 60);
            if (seconds < 10)
            {
                TimerBox.text = minutes + ":0" + seconds;
            }
            else
            {
             TimerBox.text = minutes + ":" + seconds;
            }
        }


    }

    public void TimerReset()
    {
        timerTime = 0;
    }

    public void LevelUpdate()
    {
        if (TimerBox.gameObject != null)
        {
            switch (controller.CurrentCar)
            {
                case 1:
                    LevelBox.text = "The Caboose";
                    break;
                case 2:
                    LevelBox.text = "Blocking Buttons";
                    break;
                case 3:
                    LevelBox.text = "Target Practice";
                    break;
                case 4:
                    LevelBox.text = "Follow that Bullet!";
                    break;
                case 5:
                    LevelBox.text = "Gloxing Day";
                    break;
                case 6:
                    LevelBox.text = "Do Not Despair";
                    break;
                case 7:
                    LevelBox.text = "The Beta Basics";
                    break;
                case 8:
                    LevelBox.text = "Locks and Keys";
                    break;
                default:
                    LevelBox.text = "Mysterious Traincar";
                    break;
            }
        }
    }
    public void BestTime()
    {
        switch (controller.CurrentCar - 1)
        {
            case 1:
                if (timerTime < bestTime1)
                {
                    bestTime1 = timerTime;
                }
                print(bestTime1);
                break;
            case 2:
                if (timerTime < bestTime2)
                {
                    bestTime2 = timerTime;
                }
                print(bestTime2);
                break;
            case 3:
                if (timerTime < bestTime3)
                {
                    bestTime3 = timerTime;
                }
                print(bestTime3);
                break;
            case 4:
                if (timerTime < bestTime4)
                {
                    bestTime4 = timerTime;
                }
                print(bestTime4);
                break;
            case 5:
                if (timerTime < bestTime5)
                {
                    bestTime5 = timerTime;
                }
                print(bestTime5);
                break;
            case 6:
                if (timerTime < bestTime6)
                {
                    bestTime6 = timerTime;
                }
                print(bestTime6);
                break;
            case 7:
                if (timerTime < bestTime7)
                {
                    bestTime7 = timerTime;
                }
                print(bestTime7);
                break;
            case 8:
                if (timerTime < bestTime8)
                {
                    bestTime8 = timerTime;
                }
                print(bestTime8);
                break;
            case 9:
                if (bestTime1 + bestTime2 + bestTime3 + bestTime4 + bestTime5 + bestTime6 + bestTime7 + bestTime8 < bestTime)
                {
                    bestTime = bestTime1 + bestTime2 + bestTime3 + bestTime4 + bestTime5 + bestTime6 + bestTime7 + bestTime8;
                }
                bestTime = bestTime1 + bestTime2 + bestTime3 + bestTime4 + bestTime5 + bestTime6 + bestTime7 + bestTime8;
                print(bestTime);
                break;
            default:
                break;

        }
    }
    public void DeathScreen()
    {
        if (Death.gameObject != null)
        {
        Death.gameObject.SetActive(true);
        Death2.gameObject.SetActive(true);
        }

    }
    public void DeathScreenDeath()
    {
        if (Death.gameObject != null)
        {
        Death.gameObject.SetActive(false);
        Death2.gameObject.SetActive(false);
        }

    }
}
