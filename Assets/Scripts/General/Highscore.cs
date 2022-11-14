using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    public TMP_Text WinText;
    public TMP_Text CabooseText;
    public TMP_Text BoxingText;
    public TMP_Text TargetText;
    public TMP_Text BulletText;
    public TMP_Text BasicText;
    public TMP_Text BonusText;
    float highTime = 99999;
    float bestMinutes;
    float bestSeconds;
    float cabooseMinutes;
    float cabooseSeconds;
    float boxingMinutes;
    float boxingSeconds;
    float targetMinutes;
    float targetSeconds;
    float bulletMinutes;
    float bulletSeconds;
    float basicMinutes;
    float basicSeconds;
    float bonusMinutes;
    float bonusSeconds;
    GameController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();

        if (controller.BestTime1 + controller.BestTime2 + controller.BestTime3 + controller.BestTime4 + controller.BestTime5 + controller.BestTime6 < highTime)
        {
            highTime = controller.BestTime1 + controller.BestTime2 + controller.BestTime3 + controller.BestTime4 + controller.BestTime5 + controller.BestTime6;
        }
        bestMinutes = Mathf.FloorToInt(highTime / 60);
        bestSeconds = Mathf.FloorToInt(highTime % 60);
        if (bestSeconds < 10)
        {
            WinText.text = "You win!(So far)                            Total Time:" + bestMinutes + ":0" + bestSeconds;
        }
        else
        {
            WinText.text = "You win!(So far)                            Total Time:" + bestMinutes + ":" + bestSeconds;
        }
        cabooseMinutes = Mathf.FloorToInt(controller.BestTime1 / 60);
        cabooseSeconds = Mathf.FloorToInt(controller.BestTime1 % 60);
        if (cabooseSeconds < 10)
        {
            CabooseText.text = "The Caboose:" + cabooseMinutes + ":0" + cabooseSeconds;
        }
        else
        {
            CabooseText.text = "The Caboose:" + cabooseMinutes + ":" + cabooseSeconds;
        }
        boxingMinutes = Mathf.FloorToInt(controller.BestTime2 / 60);
        boxingSeconds = Mathf.FloorToInt(controller.BestTime2 % 60);
        if (boxingSeconds < 10)
        {
            BoxingText.text = "Boxing Buttons:" + boxingMinutes + ":0" + boxingSeconds;
        }
        else
        {
            BoxingText.text = "Boxing Buttons:" + boxingMinutes + ":" + boxingSeconds;
        }
        targetMinutes = Mathf.FloorToInt(controller.BestTime3 / 60);
        targetSeconds = Mathf.FloorToInt(controller.BestTime3 % 60);
        if (targetSeconds < 10)
        {
            TargetText.text = "Target Practice:" + targetMinutes + ":0" + targetSeconds;
        }
        else
        {
            TargetText.text = "Target Practice:" + targetMinutes + ":" + targetSeconds;
        }
        bulletMinutes = Mathf.FloorToInt(controller.BestTime4 / 60);
        bulletSeconds = Mathf.FloorToInt(controller.BestTime4 % 60);
        if (bulletSeconds < 10)
        {
            BulletText.text = "Follow that Bullet:" + bulletMinutes + ":0" + bulletSeconds;
        }
        else
        {
            BulletText.text = "Follow that Bullet:" + bulletMinutes + ":" + bulletSeconds;
        }
        basicMinutes = Mathf.FloorToInt(controller.BestTime5 / 60);
        basicSeconds = Mathf.FloorToInt(controller.BestTime5 % 60);
        if (bulletSeconds < 10)
        {
            BasicText.text = "Beta Basics:" + basicMinutes + ":0" + basicSeconds;
        }
        else
        {
            BasicText.text = "Beta Basics:" + basicMinutes + ":" + basicSeconds;
        }
        bonusMinutes = Mathf.FloorToInt(controller.BestTime6 / 60);
        bonusSeconds = Mathf.FloorToInt(controller.BestTime6 % 60);
        if (bonusSeconds < 10)
        {
            BonusText.text = "Beta Bonus:" + bonusMinutes + ":0" + bonusSeconds;
        }
        else
        {
            BonusText.text = "Beta Bonus:" + bonusMinutes + ":" + bonusSeconds;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
