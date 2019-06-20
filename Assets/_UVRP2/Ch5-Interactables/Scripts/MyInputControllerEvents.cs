using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyInputControllerEvents : MonoBehaviour
{
    public XRButtonController rightTrigger;
    public XRButtonController leftTrigger;

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
        return rightTrigger.ButtonDown || leftTrigger.ButtonDown;
    }

    public bool ButtonUp()
    {
        return rightTrigger.ButtonUp || leftTrigger.ButtonUp;
    }
}
