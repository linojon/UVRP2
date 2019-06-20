using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyInputControllerPerHand : MonoBehaviour
{
    public string rightTrigger = "XRI_Right_TriggerButton";
    public string leftTrigger = "XRI_Left_TriggerButton";

    public UnityEvent RightButtonDownHandEvent;
    public UnityEvent RightButtonUpHandEvent;
    public UnityEvent LeftButtonDownHandEvent;
    public UnityEvent LeftButtonUpHandEvent;

    void Update()
    {
        if (string.IsNullOrWhiteSpace(rightTrigger) == false)
        {
            if (Input.GetButtonDown(rightTrigger))
                RightButtonDownHandEvent.Invoke();
            else if (Input.GetButtonUp(rightTrigger))
                RightButtonUpHandEvent.Invoke();
        }
        if (string.IsNullOrWhiteSpace(leftTrigger) == false)
        {
            if (Input.GetButtonDown(leftTrigger))
                LeftButtonDownHandEvent.Invoke();
            else if (Input.GetButtonUp(leftTrigger))
                LeftButtonUpHandEvent.Invoke();
        }
    }
}
