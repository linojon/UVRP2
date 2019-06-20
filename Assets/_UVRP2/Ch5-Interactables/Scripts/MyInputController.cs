using UnityEngine;

public class MyInputController : MonoBehaviour
{
    public XRButtonController rightTrigger;
    public XRButtonController leftTrigger;

    private void Start() { }

    public bool ButtonDown()
    {
        return rightTrigger.ButtonDown || leftTrigger.ButtonDown;
    }

    public bool ButtonUp()
    {
        return rightTrigger.ButtonUp || leftTrigger.ButtonUp;
    }
}
