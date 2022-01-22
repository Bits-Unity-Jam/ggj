using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private Button _pause;

    private void Awake()
    {
        _pause = GetComponent<Button>();
    }

    private void Start()
    {
        _pause.onClick.AddListener(GameManager.instance.ToPauseGame);
        _pause.onClick.AddListener(ToPause);
        
        GameManager.instance.ContinueGame += ToContinue;
    }

    private void OnDisable()
    {
        GameManager.instance.ContinueGame -= ToContinue;
    }
    public void ToPause()
    {
        _pause.interactable = false;
    }

    public  void ToContinue()
    {
        _pause.interactable = true;
    }
}
