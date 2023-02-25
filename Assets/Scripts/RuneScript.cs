using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneScript : MonoBehaviour
{
    public GameObject[] SwitchablePlatforms;

    public void swap()
    {
        foreach(GameObject i in SwitchablePlatforms)
        {
            i.GetComponent<SwitchablePlatform>().switchColors();
            //i.gameObject.GetComponent<SwitchablePlatform>().switchColors();
            Debug.Log("BAD!");
        }
    }
}
