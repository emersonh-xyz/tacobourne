using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    float someScale;

    private void Awake()
    {
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        someScale = -transform.localScale.x;
    }

    private void Update()
    {
        float movement = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

        //Flip player when facing left/right.
        if (movement > 0.01f)
            transform.localScale = new Vector2(someScale, transform.localScale.y);
        else if (movement < -0.01f)
            transform.localScale = new Vector2(-someScale, transform.localScale.y);

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
