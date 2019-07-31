using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public int speed;
    public int jumpspeed;
    public bool isGrounded = false;
    public Rigidbody2D rb;

    private void Start()
    {
    }
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("2d enabled");
    }
    void OnDisable()
    {
        Debug.Log("2d disabled");
    }
    
    void FixedUpdate()
    {
        if (Input.GetButton("Left"))
        {
            rb.AddForce(transform.right * speed);
        }
        if (Input.GetButton("Right"))
        {
            rb.AddForce(-transform.right * speed);
        }
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(transform.up * jumpspeed);
        }
    }
}