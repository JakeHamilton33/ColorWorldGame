using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool player2;
    
    public float speed;
    public float jumpForce;
    public float maxVelocity;

    public Transform checkGround;

    private bool isOnGround;
    private GameObject currentRune;
    private Rigidbody2D myBody;
    private SpriteRenderer myRenderer;
    private Animator anim;
    private LayerMask ground;

    private void Awake()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();

        ground |= (1 << LayerMask.NameToLayer("Ground"));
        if (player2)
        {
            ground |= (1 << LayerMask.NameToLayer("Player 1"));
        }
        else
        {
            ground |= (1 << LayerMask.NameToLayer("Player 2"));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckOnGround();
        if (player2)
        {
            Move2();
        }
        else
        {
            Move();
        }
        Animate();
        
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            myBody.AddForce(Vector2.right * speed * Time.deltaTime * 100);
            myBody.drag = (speed * Time.deltaTime * 100) / maxVelocity;
            myRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            myBody.AddForce(Vector2.left * speed * Time.deltaTime * 100);
            myBody.drag = (speed * Time.deltaTime * 100) / maxVelocity;
            myRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            myBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
        }
        if(Input.GetKeyDown(KeyCode.E) && currentRune != null)
        {
            currentRune.GetComponent<RuneScript>().swap();
        }
    }

    private void Move2()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myBody.AddForce(Vector2.right * speed * Time.deltaTime * 100);
            myBody.drag = (speed * Time.deltaTime * 100) / maxVelocity;
            myRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myBody.AddForce(Vector2.left * speed * Time.deltaTime * 100);
            myBody.drag = (speed * Time.deltaTime * 100) / maxVelocity;
            myRenderer.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            myBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.RightShift) && currentRune != null)
        {
            currentRune.GetComponent<RuneScript>().swap();
        }
    }

    private void CheckOnGround()
    {
        RaycastHit2D hit;

        if (hit = Physics2D.Raycast(checkGround.position, new Vector2(0f, -1f), 0.05f, ground))
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }

    private void Animate()
    {
        if(myBody.velocity.y < -0.5f)
        {
            anim.SetBool("IsFalling", true);
            anim.ResetTrigger("Jump");
        }
        else
        {
            anim.SetBool("IsFalling", false);
        }

        if (myBody.velocity.x < -0.5f || myBody.velocity.x > 0.5f)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameManager.instance.PlayDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Rune")
        {
            currentRune = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rune")
        {
            currentRune = null;
        }
    }
}
