using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonControllerEvents : MonoBehaviour
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
