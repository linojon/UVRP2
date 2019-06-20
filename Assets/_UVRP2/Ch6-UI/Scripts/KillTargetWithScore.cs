using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KillTargetWithScore : MonoBehaviour
{
    public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public float timeToSelect = 3.0f;
    public int score;
    public TextMeshProUGUI scoreText;
    public GameObject healthCanvas;
    public Image healthBar;
    private float countDown;

    // Use this for initialization
    void Start()
    {
        score = 0;
        countDown = timeToSelect;
        SetScoreText();
        SetHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == target))
        {
            if (countDown > 0f)
            {
                // on target
                countDown -= Time.deltaTime;

                hitEffect.transform.position = hit.point;
                hitEffect.Play();

            }
            else
            {
                // killed
                GameObject effect = Instantiate(killEffect, target.transform.position, target.transform.rotation);
                GameObject.Destroy(effect, 4f);

                score += 1;
                SetScoreText();

                countDown = timeToSelect;
                SetRandomPosition();
            }
        }
        else
        {
            // reset
            countDown = timeToSelect;
            hitEffect.Stop();
        }

        SetHealthUI();
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        target.transform.position = new Vector3(x, 0f, z);
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void SetHealthUI()
    {
        if (countDown < timeToSelect)
        {
            healthCanvas.SetActive(true);
            healthBar.fillAmount = countDown / timeToSelect;
        }
        else
        {
            healthCanvas.SetActive(false);
        }
            
    }
}