using UnityEngine;

public class Poppable : MonoBehaviour
{
    public GameObject popEffect;

    void OnCollisionEnter(Collision collision)
    {
        PopBalloon();
    }

    private void PopBalloon()
    {
        GameObject effect = Instantiate(popEffect, transform.position, transform.rotation);
        Destroy(effect, 1f);
        Destroy(gameObject);
    }
}
