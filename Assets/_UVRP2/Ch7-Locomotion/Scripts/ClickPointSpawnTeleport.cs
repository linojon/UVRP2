using UnityEngine;

public class ClickPointSpawnTeleport : MonoBehaviour
{
    public XRHand hand;
    public string button = "Fire1";
    public LayerMask teleportSpawnLayer;

    private Color saveColor;
    private GameObject currentTarget;
    private Camera camera;
    private int defaultMask = ~0;

    void Start()
    {
        camera = Camera.main;
        defaultMask = camera.cullingMask;
        ShowSpawnPoints(false);
    }

    void Update()
    {
        if (Input.GetButton(button))
        {
            Ray ray;
            RaycastHit hit;
            GameObject hitTarget;

            ShowSpawnPoints(true);
            hand.ShowRayPointer(true);

            if (currentTarget != null)
            {
                Unhighlight(currentTarget);
                currentTarget = null;
            }

            ray = new Ray(hand.transform.position, hand.transform.rotation * Vector3.forward);
            if (Physics.Raycast(ray, out hit, 10f, LayerMask.GetMask("TeleportSpawn")))
            {
                hitTarget = hit.collider.gameObject;

                if (hitTarget != currentTarget)
                {
                    Highlight(hitTarget);
                    currentTarget = hitTarget;
                }
            }
        }
        else 
        {
            if (currentTarget != null)
            {
                transform.position = currentTarget.transform.position;
                transform.rotation = currentTarget.transform.rotation;
            }
            ShowSpawnPoints(false);
            hand.ShowRayPointer(false);
            currentTarget = null;
        }
    }

    private void Highlight(GameObject target)
    {
        Material material;
        material = target.GetComponent<Renderer>().material;
        saveColor = material.color;
        Color hiColor = material.color;
        hiColor.a = 0.8f; // more opaque
        material.color = hiColor;
    }

    private void Unhighlight(GameObject target)
    {
        Material material;
        material = target.GetComponent<Renderer>().material;
        material.color = saveColor;
    }

    private void ShowSpawnPoints(bool enable)
    {
        if (enable)
        {
            camera.cullingMask = defaultMask | teleportSpawnLayer;
        }
        else
        {
            camera.cullingMask = defaultMask & ~teleportSpawnLayer;
        }
    }

}
