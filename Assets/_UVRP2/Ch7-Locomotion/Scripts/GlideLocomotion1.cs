using UnityEngine;

public class GlideLocomotion1 : MonoBehaviour
{
    public float velocity = 0.7f;

    void Update()
    {
        Vector3 moveDirection = Camera.main.transform.forward;
        moveDirection *= velocity * Time.deltaTime;
        moveDirection.y = 0f;
        transform.position += moveDirection;
    }
}
