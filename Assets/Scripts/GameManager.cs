using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform currentCheckpoint;

    [SerializeField]private GameObject Players;

    public void Awake()
    {
        if(instance == null)
            instance = this;

        currentCheckpoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
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
        yield return new WaitForSeconds(1.5f);
        Instantiate(Players, currentCheckpoint.transform);
    }
}
