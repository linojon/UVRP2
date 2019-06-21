using UnityEngine;
using UnityEngine.AI;

public class LookTeleport2 : MonoBehaviour
{
    public GameObject target;
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
            if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Teleport")))
            {
                NavMeshHit navHit;
                if (NavMesh.SamplePosition(hit.point, out navHit, 1f, NavMesh.AllAreas))
                    target.transform.position = navHit.position;
            }
            else
            {
                target.transform.position = transform.position;
            }
        }
    }

}
