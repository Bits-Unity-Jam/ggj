using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuiteButton : GameUI
{
    [SerializeField] private float PauseY;
    [SerializeField] private float ContinueY;

    private Button _quite;

    private new void Awake()
    {
        base.Awake();
        _quite = GetComponent<Button>();
    }
    private new void OnEnable()
    {
        base.OnEnable();
        /*_quite.onClick.AddListener();*/ //після створення івенту виходу до меню
    }
    protected override void OnPause()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), PauseY, 0.1f);
    }

    protected override void OnContinue()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), ContinueY, 0.1f);
    }
}
