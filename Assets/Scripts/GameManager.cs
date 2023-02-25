using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform checkpoint;

    private GameObject Players;

    public void Awake()
    {
        if(instance == null)
            instance = this;

        checkpoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;

        Players = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDeath()
    {
        StartCoroutine("Death");
    }

    IEnumerator Death()
    {
        //Play death animation
        yield return new WaitForSeconds(3);
        Players.transform.position = checkpoint.position;
    }
}
