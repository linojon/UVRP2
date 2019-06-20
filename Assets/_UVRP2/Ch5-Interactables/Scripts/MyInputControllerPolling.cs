using UnityEngine;

public class MyInputControllerPolling : MonoBehaviour
{
    public string rightTrigger = "XRI_Right_TriggerButton";
    public string leftTrigger = "XRI_Left_TriggerButton";

    private void Start() { }

    public bool ButtonDown()
    {
        return Input.GetButtonDown(rightTrigger) || Input.GetButtonDown(leftTrigger);
    }

    public bool ButtonUp()
    {
        return Input.GetButtonUp(rightTrigger) || Input.GetButtonUp(leftTrigger);
    }
}
