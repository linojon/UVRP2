using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class XRGrabable : MonoBehaviour
{
    private Transform _previousParent;

    private void Start()
    {
        XRHand.OnHandGrab.AddListener(OnGrab);
        XRHand.OnHandUngrab.AddListener(OnUngrab);
    }


    private void OnGrab(XRHand hand, GameObject obj)
    {
        if (obj != gameObject)
            return;

        _previousParent = transform.parent;
        transform.SetParent(hand.transform);
    }

    private void OnUngrab(XRHand hand, GameObject obj)
    {
        if (obj != gameObject)
            return;

        transform.SetParent(_previousParent);
    }
}
