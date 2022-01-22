using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : GameUI
{
    [SerializeField] private float PauseY;
    [SerializeField] private float ContinueY;
    
    
    private Button _continue;

    private new  void Awake()
    {
        base.Awake();
        _continue = GetComponent<Button>();
    }
    private new  void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(Subscribing());
    }
    
    protected override void OnPause()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), PauseY, 0.1f);
        transform.LeanScale(Vector3.one, 0.1f);
    }

    protected override void OnContinue()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), ContinueY, 0.1f);
        transform.LeanScale(Vector3.zero, 0.1f);
    }

    private  new IEnumerator Subscribing()
    {
        yield return new WaitUntil(() => _gameManager.IsEnabled && _gameManager.IsAwaked && _gameManager.IsStarted);
        DoresumeSubscribtion();
        
        void DoresumeSubscribtion()
        {
            _continue.onClick.AddListener(GameManager.instance.ToContinueGame);
        }
    }
}
