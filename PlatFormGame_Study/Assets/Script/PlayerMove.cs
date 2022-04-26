using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump"))
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        //Stop Speed
        if (Input.GetButtonUp("Horizontal"))
            rb.velocity = new Vector2(rb.velocity.normalized.x * 0.5f, rb.velocity.y); //normalized == 방향
        
        //Direction Sprite
        if (Input.GetButton("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        if (Mathf.Abs(rb.velocity.x) < 0.3)  //Mathf == 수학관련 함수 제공 클래스
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);
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
