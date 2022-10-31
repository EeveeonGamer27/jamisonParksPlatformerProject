using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class GloxBehavior : MonoBehaviour
{
    GameObject goxLox;
    Rigidbody2D rb;
    PlayerBehavior player;
    SpriteRenderer sr;
    public AudioClip Chaching;
    public float EnemySpeed;
    public bool BoxForm = false;
    // Start is called before the first frame update
    void Awake()
    {
        goxLox = GameObject.Find("GoxBoxLox");
        rb = GetComponent<Rigidbody2D>();
        sr = rb.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Eeveeon").GetComponent<PlayerBehavior>();
    }
    // Update is called once per frame
    void Update()
    {
        if (BoxForm)
        {
            transform.position = goxLox.transform.position;
        }
        else
        {        
            if (player.transform.position.x >= transform.position.x)
            {
                Vector2 newPosition = transform.position;
                newPosition.x += EnemySpeed * Time.deltaTime;
                transform.position = new Vector2(newPosition.x, newPosition.y);
                sr.flipX = false;
            }
            if (player.transform.position.x <= transform.position.x)
            {
                Vector2 newPosition = transform.position;
                newPosition.x -= EnemySpeed * Time.deltaTime;
                transform.position = new Vector2(newPosition.x, newPosition.y);
                sr.flipX = true;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (BoxForm)
            {
                BoxForm = false;
            }
            else
            {
                rb.velocity = Vector2.zero;
                AudioSource.PlayClipAtPoint(Chaching, Camera.main.transform.position);
                Invoke("RipGox", 1);
                Invoke("BecomeBox", 1.00001f);
                GetComponent<Animator>().SetTrigger("Boxing");
                this.enabled = false;
            }

        }
    }
    void RipGox()
    {
       gameObject.SetActive(false);
    }
    void BecomeBox()
    {
        goxLox.SetActive(true);
        BoxForm = true;
        this.enabled = true;
    }
    private void OnEnable()
    {
        transform.position = goxLox.transform.position;
    }
}