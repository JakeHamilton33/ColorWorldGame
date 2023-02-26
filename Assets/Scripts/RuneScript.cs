using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RuneScript : MonoBehaviour
{
    public GameObject[] bluePlatforms;
    public GameObject[] orangePlatforms;

    [SerializeField][HideInInspector] private AnimatedTile RedL, RedBridgeL, RedM, RedBridgeR, RedR, BlueL, BlueBridgeL, BlueM, BlueBridgeR, BlueR;

    private void Start()
    {
        
    }
    public void swap()
    {
        Debug.Log("Run Rune Script");
        foreach(var platform in bluePlatforms)
        {

            if(platform.activeSelf == true)
            {
                platform.SetActive(false);
            }
            else
            {
                platform.SetActive(true);
            }
        }
        foreach (var platform in orangePlatforms)
        {

            if (platform.activeSelf == true)
            {
                platform.SetActive(false);
            }
            else
            {
                platform.SetActive(true);
            }

        }

    }
}
