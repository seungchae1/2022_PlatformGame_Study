using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        //Stop Speed
        if (Input.GetButtonUp("Horizontal"))
            rb.velocity = new Vector2(rb.velocity.normalized.x * 0.5f, rb.velocity.y); //normalized == 방향
        //Direction Sprite
        if (Input.GetButton("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
    }


    void FixedUpdate()
    {
        //Move by Key Control
        float h = Input.GetAxisRaw("Horizontal");
        rb.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //velocity == Rigidbody의 현재 속도, Vector
        if (rb.velocity.x > maxSpeed)   //Right Max Speed
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        else if (rb.velocity.x < maxSpeed * (-1))   //Left Max Speed
            rb.velocity = new Vector2(maxSpeed * (-1), rb.velocity.y);
    }
}
