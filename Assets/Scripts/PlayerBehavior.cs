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
    public bool Left = false;
    bool hitWall = false;
    bool rollTime = false;
    bool playBonk = false;
    bool onGround = false;
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
        onGround = Physics2D.BoxCast(transform.position, new Vector2(.4f, .5f), -90, Vector2.down, 1, GroundMask);

        //Checks which direction you should be facing
        if (Left)
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
            if (Left)
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
                    //Ducking movement would happen here
                }
                else
                {
                    //Mid-air diving
                    ableToMove = false;
                    playBonk = true;
                    if (!Left)
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
            if (Left)
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
                Left = false;
                rb.AddRelativeForce(transform.right * Speed);
            }
            //Move left
            else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && rb.velocity.x > -15)
            {
                /*Vector2 newPosition = transform.position;
                newPosition.x -= Speed * Time.deltaTime;
                transform.position = new Vector2(newPosition.x, newPosition.y);*/
                Left = true;
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
    void NextCar()
    {
        transform.position = new Vector2(transform.position.x + 10, transform.position.y);
        this.enabled = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            
            Invoke("NextCar", 2);
            rb.velocity = Vector2.zero;
            this.enabled = false;
        }
    }

}