using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public RectTransform rt;
    [SerializeField]private  float pausedY = 1.436472f;
    [SerializeField]private  float continuedY = 897.7964f;
    
    private const float pausedX = 3.87f;
    private const float continuedX = 1;


    private void Start()
    {
        GameManager.instance.PauseGame += ToPause;
        GameManager.instance.ContinueGame += ToContinue;
    }

    private void OnDisable()
    {
        GameManager.instance.PauseGame -= ToPause;
        GameManager.instance.ContinueGame -= ToContinue;
    }

    public void ToPause()
    {
        transform.LeanScaleX(pausedX, 0.08f);
        StartCoroutine(ToDeleyMyLerping(0.08f));

    }

    public  void ToContinue() //легасі:)
    {
        StartCoroutine(Lerping(rt.SetTopY, pausedY, continuedY, 10));
        transform.LeanScaleX(continuedX, 0.1f);
    }

    private IEnumerator Lerping(Action<float> method,float firstValue, float endValue,float speed)
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
    

}


public static class RectTransformExtensions //
{
    public static void SetTopY(this RectTransform rt, float top) // не знайшов властивість Top, написав свою
    {
        rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
    }
}
