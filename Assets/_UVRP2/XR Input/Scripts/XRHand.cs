using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class XRHandEvent : UnityEvent<XRHand, GameObject> { }

public class XRHand : MonoBehaviour
{
    public string button = "XRI_Right_TriggerButton";
    public GameObject rayPointer;

    public static XRHandEvent OnHandTouch = new XRHandEvent();
    public static XRHandEvent OnHandUntouch = new XRHandEvent();
    public static XRHandEvent OnHandGrab = new XRHandEvent();
    public static XRHandEvent OnHandUngrab = new XRHandEvent();

    private GameObject _touching;

    void Start()
    {
        ShowRayPointer(false);
    }

    void Update()
    {
        if (Input.GetButtonDown(button) && _touching != null)
        {
            Debug.Log(gameObject.name + " grabbing " + _touching.name);
            OnHandGrab.Invoke(this, _touching);
        }
        else if (Input.GetButtonUp(button) && _touching != null)
        {
            Debug.Log(gameObject.name + " ungrabbing " + _touching.name);
            OnHandUngrab.Invoke(this, _touching);
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

    public void ShowRayPointer(bool enable)
    {
        if (rayPointer != null)
        {
            rayPointer.SetActive(enable);
        }
    }
}
