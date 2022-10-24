using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloxBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerBehavior player;
    SpriteRenderer sr;
    public float EnemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = rb.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Eeveeon").GetComponent<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
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
