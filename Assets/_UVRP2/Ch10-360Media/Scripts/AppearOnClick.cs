using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOnClick : MonoBehaviour
{
    public GameObject target;
    public GameObject handGlove;
    public string button = "Fire1";

    void Update()
    {
        target.SetActive(Input.GetButton(button));
        handGlove.SetActive((!Input.GetButton(button)));
    }
}
