using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RuneScript : MonoBehaviour
{
    [SerializeField][HideInInspector] private Tilemap OrangeTileset, BlueTileset;

    [SerializeField][HideInInspector] private AnimatedTile RedL, RedBridgeL, RedM, RedBridgeR, RedR, BlueL, BlueBridgeL, BlueM, BlueBridgeR, BlueR;

    public void swap()
    {
        
    }
}
