using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int targetFrameRate = 60;
    public bool Paused = false;
    public int CurrentCar;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
        CurrentCar = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Pause
        if (Input.GetKey(KeyCode.P))
        {
            if (Paused)
            {
                Paused = false;
            }
            else
            {
                Paused = true;
            }
        }
        //Restart
        if (Input.GetKey(KeyCode.L))
        {
            SceneManager.LoadScene(0);
        }

        //Escape
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
