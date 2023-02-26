using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCredits : MonoBehaviour
{
    public bool player2;

    public float speed;
    public float jumpForce;
    public float maxVelocity;

    public Transform checkGround;

    public ParticleSystem snowySteps;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("IsRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
           myBody.AddForce(Vector2.right * speed * Time.deltaTime * 100);
           myBody.drag = (speed * Time.deltaTime * 100) / maxVelocity;
           myRenderer.flipX = false;
    }

    private void spawnSnow()
    {
        snowySteps.Emit(5);
    }
}
