using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ButtonDoor : MonoBehaviour
{
    public ButtonBehavior button;
    bool rise = false;
    bool lower = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (button.Pressed)
        {
            rise = true;
            Invoke("RiseEnd", 3);
            Invoke("Lower", 5);
            Invoke("LowerEnd", 11);
        }
        if (rise)
        {
            Vector2 newPosition = transform.position;
            newPosition.y += 1 * Time.deltaTime;
            transform.position = new Vector2(newPosition.x, newPosition.y);
        }
        else if (lower)
        {
            Vector2 newPosition = transform.position;
            newPosition.y -= 0.5f * Time.deltaTime;
            transform.position = new Vector2(newPosition.x, newPosition.y);
        }
    }
    void Lower()
    {
        lower = true;
    }
    void RiseEnd()
    {
        rise = false;
    }
    void LowerEnd()
    {
        lower = false;
    }
}
