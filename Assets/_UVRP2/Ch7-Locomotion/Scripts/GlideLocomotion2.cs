using UnityEngine;

public class GlideLocomotion2 : MonoBehaviour
{
    public float velocity = 0.7f;
    public float comfortAngle = 30f;
    public string button = "Fire1";
    public string thumbStick = "Horizontal";

    private CharacterController character;
    private bool isWalking = false;
    private bool hasRotated = true;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetButtonDown(button))
            isWalking = true;
        else if (Input.GetButtonUp(button))
            isWalking = false;

        if (isWalking)
            character.SimpleMove(transform.forward * velocity);

        float axis = Input.GetAxis(thumbStick);
        if (hasRotated)
        {
            if (axis == 0f)
                hasRotated = false;
        } else
        {
            if (axis > 0.5f)
            {
                transform.Rotate(0, comfortAngle, 0);
                hasRotated = true;
            }
            if (axis < -0.5f)
            {
                transform.Rotate(0, -comfortAngle, 0);
                hasRotated = true;
            }

        }
    }
}
