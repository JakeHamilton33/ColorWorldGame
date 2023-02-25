using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private CapsuleCollider2D enemyCollider;
    private Rigidbody2D enemyRigidBody;
    public bool isFacingLeft = true;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bound")
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
    }
}
