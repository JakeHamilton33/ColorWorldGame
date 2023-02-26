using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    [SerializeField] private GameObject player1, player2, heart;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, new Vector3(player1.transform.localPosition.x, player1.transform.localPosition.y - 0.5f, -1f));
        lineRenderer.SetPosition(1, new Vector3(player2.transform.localPosition.x, player2.transform.localPosition.y - 0.5f, -1f));

        heart.transform.position = new Vector3(Mathf.Lerp(player1.transform.position.x, player2.transform.position.x, 0.5f), Mathf.Lerp(player1.transform.position.y, player2.transform.position.y, 0.5f)-0.5f, -1.5f);

    }
}
