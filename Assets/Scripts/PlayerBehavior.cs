using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using static UnityEngine.UI.Image;

public class PlayerBehavior : MonoBehaviour
{
    public float Speed;
    public float Jump;
    public float DiveSpeed;
    public float SlowDown;
    public LayerMask GroundMask;
    bool ableToMove = true;
    bool left = false;
    bool hitWall = false;
    bool rollTime = false;
    bool playBonk = false;
    bool onGround = false;
    bool sameDive = false;
    public AudioClip Bonk;
    public AudioClip Boom;
    Rigidbody2D rb;
    SpriteRenderer sr;
    AudioSource aSource;

    //Just for testing collision
    bool collisionTest = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = rb.GetComponent<SpriteRenderer>();
        aSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.BoxCast(transform.position, new Vector2(.4f, .5f), -90, Vector2.down, 1, GroundMask);

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
        if (playBonk && hitWall)
        {
            AudioSource.PlayClipAtPoint(Bonk, Camera.main.transform.position);
            playBonk = false;
        }
        //Checks if you should be rolling, then makes you roll.
        if (rollTime)
        {
            if (left)
            {
                transform.Rotate(0, 0, -360 * Time.deltaTime);
            }
            else
            {
                transform.Rotate(0, 0, 360 * Time.deltaTime);
            }
        }
        //Re-enables movement if you have just dove
        if (onGround)
        {
            playBonk = false;
            if (rollTime)
            {
                rollTime = false;
            }
            ableToMove = true;
            CancelInvoke("StopDiving");
            transform.eulerAngles = Vector3.forward * 0;
        }

        //Movement
        if (ableToMove)
        {
            //Jump, jump, jump, jump
            if (Input.GetKeyDown(KeyCode.Space) && onGround)
            {
                /*Vector2 newPosition = transform.position;
                newPosition.y += Speed * Time.deltaTime;
                transform.position = new Vector2(newPosition.x, newPosition.y);*/
                rb.AddForce(transform.up * Jump);

                if (rb.velocity.y > Jump)
                {
                    rb.velocity = rb.velocity.normalized * Jump;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                if (onGround)
                {
                    Invoke("VineBoom", 3);
                    //Ducking movement would happen here
                }
                else
                {
                    //Mid-air diving
                    ableToMove = false;
                    playBonk = true;
                    if (!left)
                    {
                        rb.AddRelativeForce(transform.right * DiveSpeed * 1);
                        transform.eulerAngles = Vector3.forward * -90;
                    }
                    else
                    {
                        rb.AddRelativeForce(transform.right * DiveSpeed * -1);
                        transform.eulerAngles = Vector3.forward * 90;
                    }
                    Invoke("StopDiving", 4);
                }
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
                    CancelInvoke("StopDiving");
                    rb.AddRelativeForce(transform.right * DiveSpeed / -4);
                    transform.eulerAngles = Vector3.forward * -90;
                    rollTime = true;
                    Invoke("StopDiving", 5);
                }
            }
            else
            {
                hitWall = Physics2D.Raycast(transform.position, Vector2.right, 1f, GroundMask);

                if (hitWall)
                {
                    CancelInvoke("StopDiving");
                    rb.AddRelativeForce(transform.right * DiveSpeed / 4);
                    transform.eulerAngles = Vector3.forward * 90;
                    rollTime = true;
                    Invoke("StopDiving", 5);
                }
            }

        }
    }
    void FixedUpdate()
    {
        if (rb.velocity.x > 25)
        {
            rb.velocity = new Vector2 (rb.velocity.x - 1, rb.velocity.y);
        }
        if (rb.velocity.x < -25)
        {
            rb.velocity = new Vector2(rb.velocity.x + 1, rb.velocity.y);
        }
        //Movement
        if (ableToMove)
        {
            //Move right
            if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && rb.velocity.x < 15)
            {
                /*Vector2 newPosition = transform.position;
                newPosition.x += Speed * Time.deltaTime;
                transform.position = new Vector2(newPosition.x, newPosition.y);*/
                left = false;
                rb.AddRelativeForce(transform.right * Speed);
            }
            //Move left
            else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && rb.velocity.x > -15)
            {
                /*Vector2 newPosition = transform.position;
                newPosition.x -= Speed * Time.deltaTime;
                transform.position = new Vector2(newPosition.x, newPosition.y);*/
                left = true;
                rb.AddRelativeForce(transform.right * -Speed);
            }
            else
            {
                Vector3 slowing = rb.velocity;
                slowing.x /= SlowDown;
                rb.velocity = slowing;
            }
        }
    }
    void StopDiving()
    {
        if(!ableToMove)
        {
            ableToMove = true;
            transform.eulerAngles = Vector3.forward * 0;
        }

    }
    void VineBoom()
    {
        aSource.clip = Boom;
        aSource.volume = .25f;
        aSource.Play();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collisionTest)
        { 
            Debug.Log("Yep, collision works.");
            collisionTest = false;
        }

    }
}