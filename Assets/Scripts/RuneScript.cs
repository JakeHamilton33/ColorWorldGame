using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneScript : MonoBehaviour
{
    public GameObject[] SwitchablePlatforms;

    public void swap()
    {
        foreach(var i in SwitchablePlatforms)
        {
            i.gameObject.GetComponent<SwitchablePlatform>().switchColors();
        }
    }
}
