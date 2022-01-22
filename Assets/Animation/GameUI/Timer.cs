using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    [SerializeField] private float PauseY=-16;
    [SerializeField] private float ContinueY=-740;
    
    [SerializeField] private float PauseSize;
    [SerializeField] private float ContinueSize;

    private TextMeshProUGUI _timeText;
    private float _timer;
    private bool _isGameStared=false;

    private void Start()
    {
        GameManager.instance.PauseGame += ToPause;
        GameManager.instance.ContinueGame += ToContinue;
        GameManager.instance.GameStart += TornOnTimer;
        
        _timeText = GetComponent<TextMeshProUGUI>();
        _timeText.text = _timer.ToString("0.0") + " sec";
    }

    private void OnDisable()
    {
        GameManager.instance.PauseGame -= ToPause;
        GameManager.instance.ContinueGame -= ToContinue;
    }

    private void Update()
    {
        if (_isGameStared)
            TickTimer();
    }

    private void TickTimer()
    {
        _timer += Time.deltaTime;
        _timeText.text = _timer.ToString("0.0") + " sec";
    }

    public void ToPause()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), PauseY, 0.1f);
        _timeText.fontSize = PauseSize;
        _isGameStared = false;
    }

    public void ToContinue()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), ContinueY, 0.1f);
        _timeText.fontSize = ContinueSize;
        _isGameStared = true;
    }

    private void TornOnTimer()
    {
        _isGameStared = true;
    }
}
