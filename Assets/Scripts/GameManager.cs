using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform currentCheckpoint;

    private float deathCooldown;

    [SerializeField]private GameObject Players;
    [SerializeField] private GameObject OrangePlayer;
    [SerializeField] private GameObject BluePlayer;

    public void Awake()
    {
        if(instance == null)
            instance = this;

        currentCheckpoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(deathCooldown > -1)
        {
            deathCooldown -= Time.deltaTime;
        }
    }

    public void PlayDeath()
    {
        if (deathCooldown <= 0)
        {
            StartCoroutine("Death");
            OrangePlayer.gameObject.GetComponent<Animator>().SetTrigger("Death");
            BluePlayer.gameObject.GetComponent<Animator>().SetTrigger("Death");
            deathCooldown = 1.5f;
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1.5f);
        OrangePlayer.transform.position = currentCheckpoint.transform.position + Vector3.left;
        BluePlayer.transform.position = currentCheckpoint.transform.position + Vector3.right;
        OrangePlayer.gameObject.GetComponent<Animator>().Play("Idle");
        BluePlayer.gameObject.GetComponent<Animator>().Play("Idle");
    }
}
