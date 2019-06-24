using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DestroyBallPooled : MonoBehaviour
{
    public float timer = 15f;

    private void DisableMe()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        Invoke("DisableMe", timer);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
