using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButtons : MonoBehaviour
{
    public Image ImageRenderer;
    public ParticleSystem particles;
    public Slider audioSlider;
    public Animator titleAnim;

    public void startGame()
    {
        titleAnim.SetTrigger("Fall");
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(1.5f);
        while(CircleWipeController.instance._radius > 0)
        {
            CircleWipeController.instance._radius -= 0.01f;
            yield return new WaitForSeconds(0.1f);
        }

        SceneManager.LoadScene("Main Scene");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void showBar()
    {
        if (audioSlider.IsActive())
        {
            audioSlider.gameObject.SetActive(false);
        }else if(audioSlider.IsActive() == false)
        {
            audioSlider.gameObject.SetActive(true);
        }
    }

    public void startFadeIn()
    {
        StartCoroutine(FadeTo());
    }

    IEnumerator FadeTo()
    {
        float alphaValue = ImageRenderer.color.a;
        Color tmp = ImageRenderer.color;

        while (alphaValue < 1)
        {
            alphaValue += .08f;
            tmp.a = alphaValue;
            ImageRenderer.color = tmp;

            yield return new WaitForSeconds(.05f);
        }
    }
}
