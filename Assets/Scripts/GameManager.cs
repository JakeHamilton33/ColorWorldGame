using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int starsColleted;
    public Transform currentCheckpoint;

    public Button pause;
    public Button play;

    private float deathCooldown;

    [SerializeField] private GameObject OrangePlayer;
    [SerializeField] private GameObject BluePlayer;
    [SerializeField] private GameObject cinemachineCamera;

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
    public void PlayWin()
    {
        StartCoroutine(nameof(WinGame));
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
    IEnumerator WinGame()
    {
        Debug.Log("WinGame Called");
        OrangePlayer.GetComponent<PlayerMove>().enabled = false;
        BluePlayer.GetComponent<PlayerMove>().enabled = false;

        cinemachineCamera.SetActive(false);

        OrangePlayer.transform.Translate(Vector3.right);
        BluePlayer.transform.Translate(Vector3.right);


        yield return new WaitForSeconds(2.0f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("CreditScene");
    }

    public void Reset()
    {
        OrangePlayer.transform.position = currentCheckpoint.transform.position + Vector3.left;
        BluePlayer.transform.position = currentCheckpoint.transform.position + Vector3.right;
        OrangePlayer.gameObject.GetComponent<Animator>().Play("Idle");
        BluePlayer.gameObject.GetComponent<Animator>().Play("Idle");
    }

    public void Pause()
    {
        pause.gameObject.SetActive(false);
        play.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Play()
    {
        Time.timeScale = 1;
        pause.gameObject.SetActive(true);
        play.gameObject.SetActive(false);
    }
}
