using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Move : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public Transform checkGround;

    private bool isOnGround;
    private Rigidbody2D myBody;
    private LayerMask ground;

    private void Awake()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
        ground |= (1 << LayerMask.NameToLayer("Ground"));
        ground |= (1 << LayerMask.NameToLayer("Player 1"));
    }

    // Update is called once per frame
    void Update()
    {
        CheckOnGround();
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myBody.AddForce(Vector2.right * speed * Time.deltaTime * 100);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myBody.AddForce(Vector2.left * speed * Time.deltaTime * 100);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            myBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
}
