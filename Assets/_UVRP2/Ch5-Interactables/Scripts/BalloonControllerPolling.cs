using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BalloonControllerPolling : MonoBehaviour
{

    public GameObject meMyselfEye;
    public GameObject balloonPrefab;
    public float floatStrength = 20f;
    public float growRate = 1.5f;

    private MyInputControllerPolling _inputControllerPolling;
    private GameObject balloon;

    void Start()
    {
        _inputControllerPolling = meMyselfEye.GetComponent<MyInputControllerPolling>();
    }

    void Update()
    {
        if (_inputControllerPolling.ButtonDown())
        {
            NewBalloon();
        }
        else if (_inputControllerPolling.ButtonUp())
        {
            ReleaseBalloon();
        }
        else if (balloon != null)
        {
            GrowBalloon();
        }
    }

    public void NewBalloon()
    {
        // only make one at a time
        if (balloon == null)
        {
            balloon = Instantiate(balloonPrefab);
        }
    }

    public void ReleaseBalloon()
    {
        if (balloon != null)
        {
            balloon.GetComponent<Rigidbody>().AddForce(Vector3.up * floatStrength);
        }
        balloon = null;
    }

    private void GrowBalloon()
    {
        balloon.transform.localScale += balloon.transform.localScale * growRate * Time.deltaTime;
    }
}
