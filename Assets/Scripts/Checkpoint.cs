using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool obtained = false;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player 2")  && !obtained)
        {
            GameManager.instance.currentCheckpoint = gameObject.transform;
            obtained = true;
            anim.SetBool("Planted", true);
        }
    }
}
