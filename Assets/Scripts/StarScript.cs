using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    private Animator anim;
    private bool collected;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player 2") && !collected)
        {

            collected = true;
            anim.SetTrigger("Collect");
            GameManager.instance.starsColleted++;
            StartCoroutine("Disable");
        }
    }
}
