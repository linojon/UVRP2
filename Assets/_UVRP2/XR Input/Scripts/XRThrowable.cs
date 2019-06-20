using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class XRThrowable : MonoBehaviour
{
    private Transform _previousParent;

    private Vector3 _velocity;
    private Vector3 _previousPosition;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        XRHand.OnHandGrab.AddListener(OnGrab);
        XRHand.OnHandUngrab.AddListener(OnUngrab);
    }

    private void Update()
    {
        // simplistic velocity averaging
        Vector3 currentVelocity = (transform.position - _previousPosition) / Time.deltaTime;
        _velocity = (_velocity + currentVelocity) / 2f;
        _previousPosition = transform.position;
    }


    private void OnGrab(XRHand hand, GameObject obj)
    {
        if (obj != gameObject)
            return;

        _previousParent = transform.parent;
        transform.SetParent(hand.transform);
        _velocity = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = true;
        _previousPosition = transform.position;
    }

    private void OnUngrab(XRHand hand, GameObject obj)
    {
        if (obj != gameObject)
            return;

        _rigidbody.velocity = _velocity;
        _rigidbody.isKinematic = false;
        _velocity = Vector3.zero;
        transform.SetParent(_previousParent);
    }
}
