using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int starsColleted;
    public Transform currentCheckpoint;

    [Header("Buttons")]
    public Button pause;
    public Button play;

    private float deathCooldown;
    private bool growPanel;

    [Header("Level Win Handling")]
    [SerializeField] private GameObject OrangePlayer;
    [SerializeField] private GameObject BluePlayer;
    [SerializeField] private GameObject cinemachineCamera;
    [SerializeField] private GameObject panel;

    public void Awake()
    {
        if(instance == null)
            instance = this;

        currentCheckpoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
    }

    private void Start()
    {
        Image image = panel.GetComponent<Image>();
        Color tempCol = image.color;
        tempCol.a = 0f;
        image.color = tempCol;
    }

    // Update is called once per frame
    void Update()
    {
        if(deathCooldown > -1)
        {
            deathCooldown -= Time.deltaTime;
        }

        if (growPanel)
        {
            Image image = panel.GetComponent<Image>();
            Color tempCol = image.color;
            tempCol.a += 0.001f;
            image.color = tempCol;

            Transform panelPos = panel.transform;
            Transform tempPos = panelPos;
            tempPos.localScale += new Vector3(0.01f, 0.01f, 0f);
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
        OrangePlayer.GetComponentInParent<LineRenderer>().enabled = false;

        cinemachineCamera.SetActive(false);

        OrangePlayer.transform.Translate(Vector3.right);
        BluePlayer.transform.Translate(Vector3.right);

        panel.SetActive(true);
        growPanel = true;


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
