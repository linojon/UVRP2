using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

// handle trigger button only on left or right hand controller
// ref https://docs.unity3d.com/2019.1/Documentation/Manual/xr_input.html

public class XRTriggerController : MonoBehaviour
{
    [SerializeField] private XRNode _XRNode;

    public UnityEvent OnPress;
    public UnityEvent OnRelease;

    public bool IsAvailable { get; private set; }
    public bool IsPressed { get; private set; }

    private InputDevice _device;
    private InputFeatureUsage<bool> _inputFeature;
    private bool _wasPressed;

    private void Start()
    {
        InputTracking.nodeAdded += _OnNodeAdded;
        _Init();
    }

    // poll device for changes
    private void Update()
    {
        if (!_device.isValid)
            return;

        bool value;
        if (_device.TryGetFeatureValue(_inputFeature, out value))
        {
            IsPressed = value;
            if (IsPressed && !_wasPressed)
            {
                Debug.Log(gameObject.name + " Trigger Pressed");
                OnPress.Invoke();
            }
            else if (!IsPressed && _wasPressed)
            {
                Debug.Log(gameObject.name + " Trigger Released");
                OnRelease.Invoke();
            }

            _wasPressed = IsPressed;
        }
        else
        {
            IsAvailable = false;
        }
    }

    // initialize device and feature references
    private void _Init()
    {
        _device = InputDevices.GetDeviceAtXRNode(_XRNode);
        _inputFeature = CommonUsages.triggerButton;
    }

    // handle reconnected device
    private void _OnNodeAdded(XRNodeState obj)
    {
        Debug.Log("Node added " + obj.nodeType);
        if (obj.nodeType == _XRNode)
        {
            _Init();
        }
    }
}
