using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBindingsTest : MonoBehaviour
{
    public string buttonName = "XRI_Right_TriggerButton"; // "Fire1"

    void Update()
    {
        if (Input.GetButtonDown(buttonName))
        {
            Debug.Log(buttonName + " down");
        }

        if (Input.GetButtonUp(buttonName))
        {
            Debug.Log(buttonName + " up");
        } 
    }
}
