using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : GameUI
{
    private Button _pause;

    private new void Awake()
    {
        base.Awake();
        _pause = GetComponent<Button>();
    }

    private new void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(Subscribing());
    }
    
    protected override void OnPause()
    {
        _pause.interactable = false;
    }

    protected override void OnContinue()
    {
        _pause.interactable = true;
    }

    private  IEnumerator Subscribing()
    {
        yield return new WaitUntil(() => GameManager.IsEnabled && GameManager.IsAwaked && GameManager.IsStarted);
        DoPauseSubscribtion();
        
        void DoPauseSubscribtion()
        {
            _pause.onClick.AddListener(GameManager.instance.ToPauseGame);
        }
    }
}
