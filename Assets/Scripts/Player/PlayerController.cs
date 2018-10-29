using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 300f;

    public bool attacking = false;

    public Vector2 direction;

    private Animator anim;
    private Rigidbody2D rb;
    private bool moving = false;
    private bool dash = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        //Send the input axis data to anim to play animations
        anim.SetFloat("SpeedX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("SpeedY", Input.GetAxisRaw("Vertical"));

        //If the game is getting no input, set the moving bool to false
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            moving = false;
        }

        //If the player is not moving set the velocity to zero
        if (moving == false)
        {
            rb.velocity = Vector2.zero;
        }

        //Check Input to add velocity to rigidbody
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            moving = true;
            rb.velocity = (new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, rb.velocity.y));
            direction = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, rb.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            moving = true;
            rb.velocity = (new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime));
            direction = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime);
        }

        if(Input.GetAxisRaw("Horizontal") == 0)
        {
            if (dash == true)
                return;

            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            if (dash == true)
                return;

            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }

        //Dash function
        if (Input.GetKeyDown("space"))
        {
            if (moving == false || dash == true)
                return;

            StartCoroutine(Dash());
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (attacking == true || dash == true)
                return;

            StartCoroutine(Slash());
        }
    }

    IEnumerator Slash()
    {
        attacking = true;
        anim.SetBool("Slash", true);
        yield return new WaitForSeconds(0.6f);
        anim.SetBool("Slash", false);
        attacking = false;
    }

    IEnumerator Dash()
    {
        dash = true;
        anim.SetBool("Roll", true);
        float initSpeed = moveSpeed;
        yield return new WaitForSeconds(0.25f);
        moveSpeed *= 2f;
        yield return new WaitForSeconds(0.25f);
        anim.SetBool("Roll", false);
        dash = false;
        moveSpeed = initSpeed;
    }
}