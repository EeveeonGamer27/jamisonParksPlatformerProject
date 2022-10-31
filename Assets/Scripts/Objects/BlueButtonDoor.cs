using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButtonDoor : MonoBehaviour
{
    public BlueButtonBehavior button;
    bool rise = false;
    Vector2 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (button.Pressed)
        {
            rise = true;
        }
        else
        {
            rise = false;
        }
        if (rise && transform.position.y < startingPosition.y + 4)
        {
            Vector2 newPosition = transform.position;
            newPosition.y += 5 * Time.deltaTime;
            transform.position = new Vector2(newPosition.x, newPosition.y);
        }
        else if (transform.position.y > startingPosition.y)
        {
            Vector2 newPosition = transform.position;
            newPosition.y -= 2 * Time.deltaTime;
            transform.position = new Vector2(newPosition.x, newPosition.y);
        }
    }
}
