using UnityEngine;

public class LookTeleport1 : MonoBehaviour
{
    public GameObject target;
    public GameObject ground;
    public string button = "Fire1";

    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit hit;

        if (Input.GetButtonDown(button))
        {
            target.SetActive(true);
        }
        else if (Input.GetButtonUp(button))
        {
            target.SetActive(false);
            transform.position = target.transform.position;
        }
        else if (target.activeSelf)
        {
            ray = new Ray(camera.position, camera.rotation * Vector3.forward);
            if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == ground))
            {
                target.transform.position = hit.point;
            }
            else
            {
                target.transform.position = transform.position;
            }
        }
    }

}
