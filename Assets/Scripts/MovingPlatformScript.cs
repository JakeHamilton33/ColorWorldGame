using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public float waitTimeX;
    public float waitTimeY;
    public int cellsUp;
    public int cellsDown;
    public int cellsLeft;
    public int cellsRight;
    public bool startRight;
    public bool startDown;

    private float speed = 0;
    private Grid worldgrid;
    private float cellX;
    private float cellY;

    private void Awake()
    {
        worldgrid = GameObject.FindGameObjectWithTag("World").GetComponent<Grid>();
    }

    private void Update()
    {
        MoveX();
        MoveY();
    }

    private void MoveX()
    {

    }

    private void MoveY()
    {

    }
}
