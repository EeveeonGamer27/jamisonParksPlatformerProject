using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Presets;
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
    public LayerMask DespairMask;
    bool ableToMove = true;
    public bool Left = false;
    public bool DespairMode = false;
    bool hitWall = false;
    bool rollTime = false;
    bool playBonk = false;
    bool onGround = false;
    bool despairCooldown = true;
    public AudioClip Bonk;
    public GameObject Screen;
    public GameObject Despair;
    Rigidbody2D rb;
    SpriteRenderer sr;
    GameController controller;
    TextKeeper textUpdate;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = rb.GetComponent<SpriteRenderer>();
        controller = GameObject.Find("GameController").GetComponent<GameController>();
        textUpdate = GameObject.Find("CameraController").GetComponent<TextKeeper>();
        Despair = GameObject.Find("Despair");
        CarStart();
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
        //Reset player in car
        if (Input.GetKey(KeyCode.R))
        {
            Screen.GetComponent<Animator>().SetBool("Blacked Out", true);
            Invoke("CarStart", 1);
            textUpdate.TimerReset();
            rb.velocity = Vector2.zero;
            this.enabled = false;
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
            GetComponent<Animator>().speed = 1;
            playBonk = false;
            if (rollTime)
            {
                rollTime = false;
            }
            ableToMove = true;
            CancelInvoke("StopDiving");
            transform.eulerAngles = Vector3.forward * 0;
        }
        else
        {
        //Despair Mode
                GetComponent<Animator>().speed = 0;
                DespairMode = Physics2D.Raycast(transform.position, Vector2.up, 1f, DespairMask)/*.transform.gameObject*/;
            if (DespairMode && despairCooldown)
            {
                Vector2 HoldingOn;
                HoldingOn.x = Despair.transform.position.x - 2;
                HoldingOn.y = Despair.transform.position.y - 3;
                transform.position = HoldingOn;
                ableToMove = false;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    DespairMode = false;
                    despairCooldown = false;
                    Invoke("CoolingOff", 1);
                }
            }
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
                    GetComponent<Animator>().SetTrigger("Bonked");
                    GetComponent<Animator>().speed = 1;
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
                    GetComponent<Animator>().SetTrigger("Bonked");
                    GetComponent<Animator>().speed = 1;
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
                Screen.GetComponent<Animator>().SetBool("Walking", true);
                Left = false;
                rb.AddRelativeForce(transform.right * Speed);
            }
            //Move left
            else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && rb.velocity.x > -15)
            {
                /*Vector2 newPosition = transform.position;
                newPosition.x -= Speed * Time.deltaTime;
                transform.position = new Vector2(newPosition.x, newPosition.y);*/
                GetComponent<Animator>().SetBool("Walking", true);
                Left = true;
                rb.AddRelativeForce(transform.right * -Speed);
            }
            else
            {
                Vector3 slowing = rb.velocity;
                slowing.x /= SlowDown;
                rb.velocity = slowing;
                Invoke("StopTalking", 0.5f);
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
    void StopTalking()
    {
        if (rb.velocity.x < 3)
        {
            GetComponent<Animator>().SetBool("Walking", false);
        }
    }
    void CoolingOff()
    {
        despairCooldown = true;
    }
    void CarStart()
    {
        textUpdate.DeathScreenDeath();
        Screen.GetComponent<Animator>().SetBool("Blacked Out", false);
        textUpdate.TimerReset();
        switch (controller.CurrentCar)
        {
            case 0:
            case 1:
                controller.Gun = false;
                transform.position = new Vector2(216, -2);
                break;
            case 2:
                controller.Gun = false;
                transform.position = new Vector2(292, -2);
                break;
            case 3:
                controller.Gun = false;
                transform.position = new Vector3(370, -2);
                break;
            default:
                controller.Gun = true;
                transform.position = new Vector2(72, -2);
                break;

        }
        
        this.enabled = true;
    }

    void ScreenDeath()
    {
        Screen.GetComponent<Animator>().SetBool("Blacked Out", true);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GetComponent<Animator>().SetTrigger("Damaged");
            Invoke("ScreenDeath", 1);
            textUpdate.Invoke("DeathScreen", 1);
            rb.velocity = Vector2.zero;
            this.enabled = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Takes you to the next car
        if (collision.tag == "Finish")
        {
            ScreenDeath();
            Invoke("CarStart", 1);
            controller.CurrentCar = controller.CurrentCar + 1;
            print(controller.CurrentCar);
            textUpdate.LevelUpdate();
            textUpdate.BestTime();
            rb.velocity = Vector2.zero;
            this.enabled = false;
        }
        if (collision.tag == "GunGiving")
        {
            controller.Gun = true;
        }
        if (collision.tag == "The End")
        {
            controller.Ending();
        }
    }

}