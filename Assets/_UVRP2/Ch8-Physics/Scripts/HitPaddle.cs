using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPaddle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // assume its a fireball for now
        ScoreKeeper.OnHit.Invoke();
    }
}
