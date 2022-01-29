using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : GameUI
{
    [SerializeField] private float PauseY=-16;
    [SerializeField] private float ContinueY=-740;
    
    [SerializeField] private float PauseSize;
    [SerializeField] private float ContinueSize;

    private TextMeshProUGUI _timeText;
    private float _timer;
    private bool _isGameStared=true;

    private new void Awake()
    {
        base.Awake();
        _timeText = GetComponent<TextMeshProUGUI>();
    }

    private new void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(Subscribing());
    }

    private new void  OnDisable()
    {
        base.OnDisable();
        GameManager.instance.GameStart -= TurnOnTimer;
        GameManager.instance.GameEnd += TurnOffTimer;
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

    protected override void OnPause()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), PauseY, 0.1f);
        _timeText.fontSize = PauseSize;
        TurnOffTimer();
    }

    protected override void OnContinue()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), ContinueY, 0.1f);
        _timeText.fontSize = ContinueSize;
        TurnOnTimer();
    }

    private void TurnOnTimer()
    {
        _isGameStared = true;
    }

    private void TurnOffTimer()
    {
        _isGameStared = false;
        DoGameEndAnimation();
    }

    private void DoGameEndAnimation()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), 122, 0.1f);
    }
    
    private  IEnumerator Subscribing()
    {
        yield return new WaitUntil(() => GameManager.IsEnabled && GameManager.IsAwaked && GameManager.IsStarted);
        DoTimerSubscribtion();
        
        void DoTimerSubscribtion()
        {
            GameManager.instance.GameStart += TurnOnTimer;
            GameManager.instance.GameEnd += TurnOffTimer;
        }
    }
}
