using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public bool Paused = false;
    public bool Gun = false;
    GameObject gunArm;
    public int CurrentCar;
    PlayerBehavior player;

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
        gunArm = GameObject.Find("Gun");
        QualitySettings.vSyncCount = 0;
        CurrentCar = 1;
    }

    private void Update()
    {
        if (Gun && gunArm != null)
        {
            gunArm.SetActive(true);
        }
        else if (gunArm != null)
        {
            gunArm.SetActive(false);
        }
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
            SceneManager.LoadScene("BetaCars");
            //player.Invoke("CarStart", 1);
        }

        //Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    public void Ending()
    {
        SceneManager.LoadScene("The End");
    }
}
