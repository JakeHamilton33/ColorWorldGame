using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleScript : MonoBehaviour
{
    public GameObject icicle;

    private bool isFalling;


    // Update is called once per frame
    void Update()
    {
        if (isFalling)
            Fall();
    }

    public void Fall()
    {
        icicle.transform.Translate(Vector2.down * Time.deltaTime * 6f);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player 2")
        StartCoroutine("IcicleFall");
    }

    IEnumerator IcicleFall()
    {
        for (int i = 0; i < 10; i++)
        {
            icicle.transform.Translate(new Vector3(0, 0.05f, 0));
            yield return new WaitForSeconds(0.05f);
            icicle.transform.Translate(new Vector3(0, -0.05f, 0));
            yield return new WaitForSeconds(0.05f);
        }
        isFalling = true;
    }
}
