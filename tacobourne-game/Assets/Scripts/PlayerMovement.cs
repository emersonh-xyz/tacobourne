using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        /*
         * Horizontal movement controller
         * Returns 1 or -1 depending on if A or D is presseds
        */

        var movement = Input.GetAxis("Horizontal"); 
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        /*
         * Vetical movement controller
         * If jump key pressed and y position is 0 add force to rigidbody
        */

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f) 
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
