using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGlow : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public ParticleSystem particles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player 2")
        {
            Debug.Log("hi");
            StartCoroutine(FadeTo());
            particles.Play();
            Destroy(this.gameObject.GetComponent<Collider2D>());
        }
    }
    IEnumerator FadeTo()
    {
        float alphaValue = spriteRenderer.color.a;
        Color tmp = spriteRenderer.color;

        while(alphaValue < 1)
        {
            alphaValue += .08f;
            tmp.a = alphaValue;
            spriteRenderer.color = tmp;

            yield return new WaitForSeconds(.05f);
        }
    }
}
