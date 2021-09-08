using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

public class ActiveAllDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        if (Display.displays.Length >= 2)
            Display.displays[1].Activate();

        Display.displays[0].SetParams(1992, 1344, 0, 0);
        Screen.SetResolution(1992, 1344, false);
    }
}
