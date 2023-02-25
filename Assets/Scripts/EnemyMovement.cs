using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private CapsuleCollider2D enemyCollider;
    private Rigidbody2D enemyRigidBody;
    public CircleCollider2D groundcheck;
    public CircleCollider2D wallCheck;

    private void Awake()
    {
        enemyCollider = this.GetComponent<CapsuleCollider2D>();
        enemyRigidBody = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.transform.localScale = new Vector3(1, 1, 1);
    }
}
