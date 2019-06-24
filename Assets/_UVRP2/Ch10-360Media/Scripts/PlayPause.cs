using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayPause : MonoBehaviour
{
    public string button = "Fire1";
    private VideoPlayer player;

    void Start()
    {
        player = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (Input.GetButtonDown(button))
        {
            if (player.isPlaying)
            {
                player.Pause();
            }
            else
            {
                player.Play();
            }
        }
    }
}
