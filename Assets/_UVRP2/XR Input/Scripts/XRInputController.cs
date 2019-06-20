using UnityEngine;
using UnityEngine.Events;

public class XRInputController : MonoBehaviour
{
    public XRButtonController leftTrigger;
    public XRButtonController rightTrigger;
    public UnityEvent OnTriggerPressed = new UnityEvent();
    public UnityEvent OnTriggerReleased = new UnityEvent();

    public XRButtonController lastPressed { get; private set; }

    private void Start()
    {
        leftTrigger.OnPress.AddListener(() => _OnTriggerPressed(leftTrigger));
        rightTrigger.OnPress.AddListener(() => _OnTriggerPressed(rightTrigger));
        leftTrigger.OnRelease.AddListener(() => _OnTriggerReleased(leftTrigger));
        rightTrigger.OnRelease.AddListener(() => _OnTriggerReleased(rightTrigger));
    }

    public XRButtonController AnyTriggerPressed()
    {
        if (leftTrigger.IsPressed)
        {
            return leftTrigger;
        }
        else if (rightTrigger.IsPressed)
        {
            return rightTrigger;
        }
        else
        {
            return null;
        }
    }

    private void _OnTriggerPressed(XRButtonController hand)
    {
        lastPressed = hand;
        OnTriggerPressed.Invoke();
    }

    private void _OnTriggerReleased(XRButtonController hand)
    {
        OnTriggerReleased.Invoke();
    }

}
