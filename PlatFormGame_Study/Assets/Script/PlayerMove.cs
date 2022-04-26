using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move by Key Control
        float h = Input.GetAxisRaw("Horizontal");
        rb.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //velocity == Rigidbody의 현재 속도, Vector
        if (rb.velocity.x > maxSpeed)   //Right Max Speed
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        if (rb.velocity.x < maxSpeed * (-1))   //Left Max Speed
            rb.velocity = new Vector2(maxSpeed * (-1), rb.velocity.y);
    }
}
