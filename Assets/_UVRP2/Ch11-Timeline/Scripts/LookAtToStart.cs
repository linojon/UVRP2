using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class LookAtToStart : MonoBehaviour
{
    public PlayableDirector timeline;
    public float timeToSelect = 3f;
    public GameObject countdownCanvas;
    public Text coundownText;

    private float countDown;
    private bool playToSetup;
    private double duration;
    private bool resetSetup;

    void Start()
    {
        countDown = timeToSelect;
        resetSetup = true;
        countdownCanvas.SetActive(false);
     }

    void Update()
    {
        if (timeline.state == PlayState.Playing)
        {
            return;
        }
        if (resetSetup)
        {
            StartCoroutine("PlayToSetup");
            resetSetup = false;
        }

        // Is user looking here?
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == gameObject))
        {
            if (countDown > 0f)
            {
                countDown -= Time.deltaTime;
                //Debug.Log("Counting" + countDown);
                countdownCanvas.SetActive(true);
                coundownText.text = countDown.ToString("F0");
            }
            else
            {
                // go!
                //Debug.Log("Go!");
                countdownCanvas.SetActive(false);
                timeline.Play();
                resetSetup = true;
            }
        }
        else
        {
            // reset timer
            //Debug.Log("ResetTimer");
            countDown = timeToSelect;
            countdownCanvas.SetActive(false);
        }
    }

    IEnumerator PlayToSetup()
    {
        timeline.Play();
        yield return new WaitForSeconds(0.1f);
        timeline.Stop();
    }
}
