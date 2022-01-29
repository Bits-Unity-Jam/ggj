using System;
using System.Collections;
using UnityEngine;

public class Panel : GameUI
{
    [SerializeField] RectTransform rt;
    [SerializeField]private  float pausedY = 1.436472f;
    [SerializeField]private  float continuedY = 897.7964f;
    
    private const float PausedX = 3.87f;
    private const float ContinuedX = 1;


    private new void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(Subscribing());
    }
    
    protected override void OnPause()
    {
        transform.LeanScaleX(PausedX, 0.08f);
        StartCoroutine(ToDeleyMyLerping(0.09f));
    }

    protected override void OnContinue() 
    {
        StartCoroutine(Lerping(rt.SetTopY, pausedY, continuedY, 10));
        transform.LeanScaleX(ContinuedX, 0.1f);
    }

    private void OnGameEnd()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), 204.3051f, 0.1f);
        transform.localScale = new Vector3(1, 2.5f, 1);
    }
    

    private IEnumerator Lerping(Action<float> method,float firstValue, float endValue,float speed)//легасі :)
    {
        float t = 0;
        while (t <1+speed) 
        {
            var value=Mathf.Lerp(firstValue, endValue, t);
            method.Invoke(value);
            t += speed;
            yield return null;
        }
        
    }
    private IEnumerator ToDeleyMyLerping(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Lerping(rt.SetTopY, continuedY, pausedY,0.4f));
    }
    
    private  IEnumerator Subscribing()
    {
        yield return new WaitUntil(() => GameManager.IsEnabled && GameManager.IsAwaked && GameManager.IsStarted);
        DoPanelSubscribtion();
        
        void DoPanelSubscribtion()
        {
            GameManager.instance.GameEnd += OnGameEnd;
        }
    }
   
}

public static class RectTransformExtensions //
{
    public static void SetTopY(this RectTransform rt, float top) // не знайшов властивість Top, написав свою
    {
        rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
    }
}
