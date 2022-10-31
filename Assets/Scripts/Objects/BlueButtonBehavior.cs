using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButtonBehavior : MonoBehaviour
{
    public bool Pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Pressed)
        {
            GetComponent<Animator>().SetBool("BeingHeldDown", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("BeingHeldDown", false);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Pressed = true;
        }
        else if (collision.gameObject.tag == "Player")
        {
            Pressed = true;
        }
        else if(collision.gameObject.tag == "Destroyer")
        {
            Pressed = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Pressed = false;
        }
        else if (collision.gameObject.tag == "Player")
        {
            Pressed = false;
        }
        else if (collision.gameObject.tag == "Destroyer")
        {
            Pressed = false;
        }
    }
    void Unpress()
    {
        GetComponent<Animator>().SetBool("BeingHeldDown", false);
        Pressed = false;
    }
}