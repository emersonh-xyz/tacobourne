using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D body;
    private Animator anim;


    private bool grounded;
    private bool facingRight;

    float playerScale;

    private void Awake()
    {
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0, 180f, 0f);
    }

    private void Update()
    {
        float movement = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

        //Flip player when facing left/right.
        if (movement > 0.01f && !facingRight)
            Flip();
        else if (movement < -0.01f && facingRight)
            Flip();

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        //sets animation parameters
        //anim.SetBool("run", horizontalInput != 0);
        //anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
