using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    public float timer = 15f;

    void Start()
    {
        Destroy(gameObject, timer);
    }
}
