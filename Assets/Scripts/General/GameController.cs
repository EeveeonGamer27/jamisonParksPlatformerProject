using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    //Times to remember
    public float BestTime1 = 999;
    public float BestTime2 = 999;
    public float BestTime3 = 999;
    public float BestTime4 = 999;
    public float BestTime5 = 999;
    public float BestTime6 = 999;
    public float BestTime7 = 999;
    public float BestTime8 = 999;
    public float BestTime = 99999;
    public float TimerTime;

    public bool Paused = false;
    public bool Segmented = false;
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
        QualitySettings.vSyncCount = 0;
    }

    private void Update()
    {

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
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("BetaCars");
        }

        //Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("LevelMenu");
        CurrentCar = 0;
    }
    public void Ending()
    {
        SceneManager.LoadScene("The End");
        CurrentCar = 0;
    }
}
