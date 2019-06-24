using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

[System.Serializable]
public class XRHandEvent : UnityEvent<XRHand, GameObject> { }

public class XRHand : MonoBehaviour
{
    public XRNode XRNode;
    public string button = "XRI_Right_TriggerButton";
    public GameObject handModel;
    public GameObject rayPointer;

    public static XRHandEvent OnHandTouch = new XRHandEvent();
    public static XRHandEvent OnHandUntouch = new XRHandEvent();
    public static XRHandEvent OnHandGrab = new XRHandEvent();
    public static XRHandEvent OnHandUngrab = new XRHandEvent();

    private InputDevice _device;
    private GameObject _touching;

    void Start()
    {
        ShowHandModel(false);
        ShowRayPointer(false);

        InputTracking.nodeAdded += _OnNodeAdded;
        InputTracking.trackingAcquired += _OnNodeAdded;

        InputTracking.nodeRemoved += _OnNodeRemoved;
        InputTracking.trackingLost += _OnNodeRemoved;

        _InitDevice();
    }

    void Update()
    {
        if (_device.isValid == false)
            return;

        if (Input.GetButtonDown(button) && _touching != null)
        {
            Debug.Log(gameObject.name + " grabbing " + _touching.name);
            OnHandGrab.Invoke(this, _touching);
        }
        else if (Input.GetButtonUp(button) && _touching != null)
        {
            Debug.Log(gameObject.name + " ungrabbing " + _touching.name);
            OnHandUngrab.Invoke(this, _touching);
            // also untouch when ungrab to be sure
            OnHandUntouch.Invoke(this, _touching);
            _touching = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " touching " + other.gameObject.name);
        _touching = other.gameObject;
        OnHandTouch.Invoke(this, _touching);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log(gameObject.name + " untouching " + other.gameObject.name);
        _touching = null;
        OnHandUntouch.Invoke(this, _touching);
    }

    public void ShowHandModel(bool enable)
    {
        if (handModel != null)
        {
            handModel.SetActive(enable);
        }
    }

    public void ShowRayPointer(bool enable)
    {
        if (rayPointer != null)
        {
            rayPointer.SetActive(enable);
        }
    }

    // initialize device and feature references
    private void _InitDevice()
    {
        _device = InputDevices.GetDeviceAtXRNode(XRNode);
        ShowHandModel(_device.isValid);
    }

    // handle reconnected device
    private void _OnNodeAdded(XRNodeState obj)
    {
        if (obj.nodeType == XRNode)
        {
            Debug.Log("Node added " + obj.nodeType);
            _InitDevice();
        }
    }

    // handle disonnected device
    private void _OnNodeRemoved(XRNodeState obj)
    {
        if (obj.nodeType == XRNode)
        {
            ShowHandModel(false);
            ShowRayPointer(false);
        }
    }
}
