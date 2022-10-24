using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public float scrollSpeed = 3;
    public const float ScrollWidth = 8;
    public GameObject Camera;
    // background width in pixels / pixels per Unit
    void FixedUpdate()
    {
        //Getting the current background position
        Vector2 pos = transform.position;

        //Moving the object to the left
        pos.x -= scrollSpeed * Time.deltaTime;

        //Check if the object is completely off the screen
        if (transform.position.x < Camera.transform.position.x - (3 * ScrollWidth))
        {
            OffScreen(ref pos);
        }

        //Updating the postion to the new place
        transform.position = pos;
    }

    public virtual void OffScreen(ref Vector2 pos)
    {
        pos.x = Camera.transform.position.x + (3 * ScrollWidth);
    }
}