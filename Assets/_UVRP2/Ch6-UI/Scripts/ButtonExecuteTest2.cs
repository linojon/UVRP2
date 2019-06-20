//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonExecuteTest2 : MonoBehaviour
{
    public GameObject startButton;
    public GameObject stopButton;
    private bool isOn = false;
    private float timer = 5.0f;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            isOn = !isOn;
            timer = 0.5f;

            PointerEventData data = new PointerEventData(EventSystem.current);
            if (isOn)
            {
                ExecuteEvents.Execute<IPointerClickHandler>(startButton, data, ExecuteEvents.pointerClickHandler);
            }
            else
            {
                ExecuteEvents.Execute<IPointerClickHandler>(stopButton, data, ExecuteEvents.pointerClickHandler);
            }
        }
    }
}
