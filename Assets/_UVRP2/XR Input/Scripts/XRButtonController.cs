using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

// handle one specified button on left or right controller 
// (eg doesnt get float axis value of button squeeze)
// ref https://forum.unity.com/threads/any-example-of-the-new-2019-1-xr-input-system.629824/
// ref https://docs.unity3d.com/2019.1/Documentation/Manual/xr_input.html#post-4230553

public class XRButtonController : MonoBehaviour
{
    static readonly Dictionary<string, InputFeatureUsage<bool>> availableButtons = new Dictionary<string, InputFeatureUsage<bool>>
    {
        {"TriggerButton", CommonUsages.triggerButton },
        {"Thumbrest", CommonUsages.thumbrest },
        {"Primary2DAxisClick", CommonUsages.primary2DAxisClick },
        {"Primary2DAxisTouch", CommonUsages.primary2DAxisTouch },
        {"MenuButton", CommonUsages.menuButton },
        {"GripButton", CommonUsages.gripButton },
        {"SecondaryButton", CommonUsages.secondaryButton },
        {"SecondaryTouch", CommonUsages.secondaryTouch },
        {"PrimaryButton", CommonUsages.primaryButton },
        {"PrimaryTouch", CommonUsages.primaryTouch },
    };

    public enum ButtonUsageType
    {
        TriggerButton,
        Thumbrest,
        Primary2DAxisClick,
        Primary2DAxisTouch,
        MenuButton,
        GripButton,
        SecondaryButton,
        SecondaryTouch,
        PrimaryButton,
        PrimaryTouch
    };

    //------------------

    [SerializeField] private XRNode _XRNode;
    [SerializeField] private ButtonUsageType _buttonUsageType;

    public UnityEvent OnPress;
    public UnityEvent OnRelease;

    public bool IsAvailable { get; private set; }
    public bool IsPressed { get; private set; }
    public bool ButtonDown { get; private set; }
    public bool ButtonUp { get; private set; }


    private InputDevice _device;
    private InputFeatureUsage<bool> _inputFeature;
    private bool _wasPressed;

    //--------------------

    private void Start()
    {
        InputTracking.nodeAdded += _OnNodeAdded;
        _Init();
    }

    // poll device for changes
    private void Update()
    {
        ButtonDown = false;
        ButtonUp = false;

        if (!_device.isValid || _inputFeature.name == null)
            return;

        bool value;
        if (_device.TryGetFeatureValue(_inputFeature, out value))
        {
            IsPressed = value;
            if (IsPressed && !_wasPressed)
            {
                Debug.Log(gameObject.name + " " + _buttonUsageType + " Pressed");
                ButtonDown = true;
                OnPress.Invoke();
            }
            else if (!IsPressed && _wasPressed)
            {
                Debug.Log(gameObject.name + " " + _buttonUsageType + " Released");
                ButtonUp = true;
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
        if (!_device.isValid)
            return;

        // get input feature button specified in inspector
        List<InputFeatureUsage> inputFeatures = new List<InputFeatureUsage>();
        if (_device.TryGetFeatureUsages(inputFeatures))
        {
            foreach (InputFeatureUsage feature in inputFeatures)
            {
                if (feature.name == _buttonUsageType.ToString() && availableButtons.ContainsKey(feature.name))
                {
                    IsAvailable = true;
                    _inputFeature = availableButtons[feature.name];
                    break;
                }
            }
        }
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
