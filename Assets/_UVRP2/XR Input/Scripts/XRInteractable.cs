using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class XRInteractable : MonoBehaviour
{
    public UnityEvent OnTouch = new UnityEvent();
    public UnityEvent OnUntouch = new UnityEvent();
    public UnityEvent OnSelect = new UnityEvent();
    public UnityEvent OnUnselect = new UnityEvent();

    private void Start()
    {
        XRHand.OnHandTouch.AddListener(_OnHandTouch);
        XRHand.OnHandUngrab.AddListener(_OnHandUntouch);
        XRHand.OnHandGrab.AddListener(_OnHandGrab);
        XRHand.OnHandUngrab.AddListener(_OnHandUngrab);
    }

    private void _OnHandTouch(XRHand hand, GameObject obj)
    {
        if (obj != gameObject)
            return;

        OnTouch.Invoke();
    }

    private void _OnHandUntouch(XRHand hand, GameObject obj)
    {
        if (obj != gameObject)
            return;

        OnUntouch.Invoke();
    }

    private void _OnHandGrab(XRHand hand, GameObject obj)
    {
        if (obj != gameObject)
            return;

        OnSelect.Invoke();
    }

    private void _OnHandUngrab(XRHand hand, GameObject obj)
    {
        if (obj != gameObject)
            return;

        OnUnselect.Invoke();
    }
}
