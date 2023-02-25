using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool obtained = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !obtained)
        {
            GameManager.instance.checkpoint = gameObject.transform;
            obtained = true;
            print("Checkpoint Changed");
        }
    }
}
