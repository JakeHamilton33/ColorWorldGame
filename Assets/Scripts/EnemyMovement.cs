using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private CapsuleCollider2D enemyCollider;
    private Rigidbody2D enemyRigidBody;
    public CircleCollider2D groundcheck;
    public CircleCollider2D wallCheck;
    private bool isFacingLeft = true;

    private void Awake()
    {
        enemyCollider = this.GetComponent<CapsuleCollider2D>();
        enemyRigidBody = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(isFacingLeft == true)
        {
            enemyRigidBody.velocity = Vector2.left * 1f;
        }
        else
        {
            enemyRigidBody.velocity = Vector2.right * 1f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(isFacingLeft == true)
        {
            this.transform.localScale = new Vector3(-1, this.transform.localScale.y, this.transform.localScale.z);
            isFacingLeft = false;
        }
        else
        {
            this.transform.localScale = new Vector3(1, this.transform.localScale.y, this.transform.localScale.z);
            isFacingLeft = true;
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            if (isFacingLeft == true)
            {
                this.transform.localScale = new Vector3(-1, this.transform.localScale.y, this.transform.localScale.z);
                isFacingLeft = false;
            }
            else
            {
                this.transform.localScale = new Vector3(1, this.transform.localScale.y, this.transform.localScale.z);
                isFacingLeft = true;
            }
        }
    }*/
}
