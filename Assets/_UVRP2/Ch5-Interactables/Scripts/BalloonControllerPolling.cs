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

    private MyInputController inputController;
    private GameObject balloon;

    void Start()
    {
        inputController = meMyselfEye.GetComponent<MyInputController>();
    }

    void Update()
    {
        if (inputController.ButtonDown())
        {
            NewBalloon();
        }
        else if (inputController.ButtonUp())
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
        balloon = Instantiate(balloonPrefab);
    }

    public void ReleaseBalloon()
    {
        balloon.GetComponent<Rigidbody>().AddForce(Vector3.up * floatStrength);
        balloon = null;
    }

    private void GrowBalloon()
    {
        balloon.transform.localScale += balloon.transform.localScale * growRate * Time.deltaTime;
    }
}
