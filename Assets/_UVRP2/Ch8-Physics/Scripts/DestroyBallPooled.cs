using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBallPooled : MonoBehaviour
{
    public float timer = 15f;

    void Update()
    {
        if (transform.position.y < -5f)
            DisableMe();
    }

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
