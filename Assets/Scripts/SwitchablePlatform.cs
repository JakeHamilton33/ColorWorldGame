using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchablePlatform : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite orangePlatform;
    public Sprite bluePlatform;

    private void Awake()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void switchColors()
    {
        if (this.gameObject.layer == 6)
        {
            this.gameObject.layer = 7;
            spriteRenderer.sprite = orangePlatform;
            Debug.Log("Switch!");
        }else if (this.gameObject.layer == 7){
            this.gameObject.layer = 6;
            spriteRenderer.sprite = bluePlatform;
            Debug.Log("Switch!!");
        }
    }
}
