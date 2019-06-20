using UnityEngine;
using UnityEngine.UI;

public class ButtonExecuteTest1 : MonoBehaviour
{
    public Button startButton;
    public Button stopButton;

    private bool isOn = false;
    private float timer = 5f;

    // toggle the hose on/off at 5 second intervals
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            isOn = !isOn;
            timer = 5f;

            if (isOn)
            {
                stopButton.onClick.Invoke();
            }
            else
            {
                startButton.onClick.Invoke();
            }
        }
    }
}