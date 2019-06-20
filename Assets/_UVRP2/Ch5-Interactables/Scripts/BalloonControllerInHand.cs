using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonControllerInHand : MonoBehaviour
{
    public GameObject balloonPrefab;
    public float floatStrength = 20f;
    public float growRate = 1.5f;

    private GameObject balloon;

    void Update()
    {
        if (balloon != null)
        {
            GrowBalloon();
        }
    }

    public void NewBalloon(GameObject parentHand)
    {
        if (balloon == null)
        {
            balloon = Instantiate(balloonPrefab);
            balloon.transform.SetParent(parentHand.transform);
            balloon.transform.localPosition = Vector3.zero;
        }
    }

    public void ReleaseBalloon()
    {
        if (balloon != null)
        {
            balloon.transform.parent = null;
            balloon.GetComponent<Rigidbody>().AddForce(Vector3.up *
                                                       floatStrength);
        }
        balloon = null;
    }

    private void GrowBalloon()
    {
        balloon.transform.localScale += balloon.transform.localScale * growRate * Time.deltaTime;
    }
}
