using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public int serves;
    public int hits;

    public Text servesText;
    public Text hitsText;

    public static UnityEvent OnServe = new UnityEvent();
    public static UnityEvent OnHit = new UnityEvent();

    private void Start()
    {
        OnServe.AddListener(AddServe);
        OnHit.AddListener(AddHit);
        NewGame();
    }

    public void NewGame()
    {
        serves = 0;
        hits = 0;
        _ShowScore(servesText, serves);
        _ShowScore(hitsText, hits);
    }

    public void AddServe()
    {
        _ShowScore(servesText, ++serves);
    }

    public void AddHit()
    {
        _ShowScore(hitsText, ++hits);
    }
    
    private void _ShowScore(Text text, int value)
    {
        if (text != null)
            text.text = value.ToString();
    }
}
