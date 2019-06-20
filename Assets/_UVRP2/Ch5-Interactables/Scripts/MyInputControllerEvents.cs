using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyInputControllerEvents : MonoBehaviour
{
    public string rightTrigger = "XRI_Right_TriggerButton";
    public string leftTrigger = "XRI_Left_TriggerButton";

    public UnityEvent ButtonDownEvent;
    public UnityEvent ButtonUpEvent;

    void Update()
    {
        if (ButtonDown())
            ButtonDownEvent.Invoke();
        else if (ButtonUp())
            ButtonUpEvent.Invoke();
    }

    public bool ButtonDown()
    {
        return Input.GetButtonDown(rightTrigger) || Input.GetButtonDown(leftTrigger);
    }

    public bool ButtonUp()
    {
        return Input.GetButtonUp(rightTrigger) || Input.GetButtonUp(leftTrigger);
    }
}
