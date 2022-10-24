using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
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
            GetComponent<Animator>().SetTrigger("Pressing");
            Invoke("Unpress", 5);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Pressed = true;
        }
        if (collision.gameObject.tag == "Player")
        {
            Pressed = true;
        }
    }
    void Unpress()
    {
        Pressed = false;
    }
}
