using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTarget : MonoBehaviour
{
    private AudioSource hitSound;

    void Start()
    {
        hitSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        hitSound.Play();
        ScoreKeeper.OnHit.Invoke();
    }
}
