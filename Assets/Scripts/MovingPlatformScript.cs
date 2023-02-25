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

    private Vector3 start;
    private bool isMovingRight;
    private bool isMovingDown;
    private float speed = 3f;
    private Grid worldgrid;
    private float cellX;
    private float cellY;

    private void Awake()
    {
        worldgrid = GameObject.FindGameObjectWithTag("World").GetComponent<Grid>();
        cellX = worldgrid.cellSize.x;
        cellY = worldgrid.cellSize.y;
    }

    private void Start()
    {
        isMovingRight = startRight;
        isMovingDown = startDown;
        start = transform.position;
    }

    private void Update()
    {
        if(cellsLeft != 0 || cellsRight != 0)
            MoveX();
        if(cellsUp != 0 || cellsDown != 0)
            MoveY();
    }

    private void MoveX()
    {
        if (transform.position.x > start.x + (cellX * cellsRight))
        {
            isMovingRight = false;
        }
            
        if (transform.position.x < start.x - (cellX * cellsLeft))
        {
            isMovingRight = true;
        }
            
        if (isMovingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    private void MoveY()
    {
        if (transform.position.y > start.y + (cellY * cellsUp))
        {
            isMovingDown = true;
        }

        if (transform.position.y < start.y - (cellY * cellsDown))
        {
            isMovingDown = false;
        }

        if (isMovingDown)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
}
