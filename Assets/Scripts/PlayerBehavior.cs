using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerBehavior : MonoBehaviour
{
    public float Speed;
    public LayerMask GroundMask;
    bool ableToMove = true;
    bool left = false;
    bool hitWall = false;
    bool rollTime = false;
    bool playAudio = false;
    public AudioClip Bonk;
    Rigidbody2D rb;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = rb.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        bool OnGround = Physics2D.Raycast(transform.position, Vector2.down, 1f, GroundMask);

        //Checks which direction you should be facing
        if (left)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        //BONK
        if (playAudio && hitWall)
        {
            AudioSource.PlayClipAtPoint(Bonk, Camera.main.transform.position);
            playAudio = false;
        }
        //Checks if you should be rolling, then makes you roll.
        if (rollTime)
        {
            if(left)
            {
                transform.Rotate(0, 0, -360 * Time.deltaTime);
            }
            else
            {
                transform.Rotate(0, 0, 360 * Time.deltaTime);
            }
        }
        //Re-enables movement if you have just dove
        if (OnGround)
        {
            playAudio = false;
            if (rollTime)
            {
                rollTime = false;
            }
            ableToMove = true;
            transform.eulerAngles = Vector3.forward * 0;
        }

        //Movement
        if (ableToMove)
        {
            //Jump, jump, jump, jump
            if (Input.GetKeyDown(KeyCode.Space) && OnGround)
            {
                    /*Vector2 newPosition = transform.position;
                    newPosition.y += Speed * Time.deltaTime;
                    transform.position = new Vector2(newPosition.x, newPosition.y);*/
                    rb.AddRelativeForce(transform.up * Speed * 100 * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                if (OnGround)
                {
                    //Ducking movement would happen here
                }
                else
                {
                    //Mid-air diving
                    ableToMove = false;
                    playAudio = true;
                    if (!left)
                    {
                        rb.AddRelativeForce(transform.right * Speed * 500 * Time.deltaTime);
                        transform.eulerAngles = Vector3.forward * -90;
                    }
                    else
                    {
                        rb.AddRelativeForce(transform.right * Speed * -500 * Time.deltaTime);
                        transform.eulerAngles = Vector3.forward * 90;
                    }
                }
            }
            //Move right
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                /*Vector2 newPosition = transform.position;
                newPosition.x += Speed * Time.deltaTime;
                transform.position = new Vector2(newPosition.x, newPosition.y);*/
                left = false;
                rb.AddRelativeForce(transform.right * Speed * Time.deltaTime);
            }
            //Move left
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                /*Vector2 newPosition = transform.position;
                newPosition.x -= Speed * Time.deltaTime;
                transform.position = new Vector2(newPosition.x, newPosition.y);*/
                left = true;
                rb.AddRelativeForce(transform.right * -Speed * Time.deltaTime);
            }
            else
            {
                
            }
        }
        else
        {
            //Bonking 
            if (left)
            {
                hitWall = Physics2D.Raycast(transform.position, Vector2.left, 1f, GroundMask);
                
                if (hitWall)
                {
                    rb.AddRelativeForce(transform.right * -Speed * 20 * Time.deltaTime);
                    transform.eulerAngles = Vector3.forward * -90;
                    rollTime = true;
                }
            }
            else
            {
                hitWall = Physics2D.Raycast(transform.position, Vector2.right, 1f, GroundMask);

                if (hitWall)
                {
                    rb.AddRelativeForce(transform.right * Speed * 20 * Time.deltaTime);
                    transform.eulerAngles = Vector3.forward * 90;
                    rollTime = true;
                }
            }

        }
    }
}
