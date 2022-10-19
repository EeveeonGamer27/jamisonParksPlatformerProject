using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int targetFrameRate = 60;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }

    // Update is called once per frame
    void Update()
    {
        //Restart
        if (Input.GetKey(KeyCode.R))
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
