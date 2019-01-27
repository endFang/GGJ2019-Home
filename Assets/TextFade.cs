using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFade : MonoBehaviour
{
    public bool trigger = false;
    public bool fadeOut;
    public bool fadeIn;


    public float fadeTime = 2f;
    public float outTimer;
    public float inTimer;

    

    public Text[] allCreditText;
    private int totalText;
    private int ctIndex;



    public void Start()
    {
        allCreditText[0].enabled = true;
        ctIndex = 0;
        totalText = allCreditText.Length - 1;
        trigger = true;
        
        inTimer = fadeTime;
        outTimer = fadeTime;
        fadeOut = true;
        fadeIn = false;

        
    }

    public void begin()
    {
        trigger = true;
    }

    public void end()
    {
        gameObject.SetActive(false);
    }


    public void Update()
    {
        if (trigger)
        {
            // Debug.Log(outTimer);
            if (fadeOut)
            {
                if (outTimer == fadeTime)
                {
                    fadeOutCall();
                    outTimer -= Time.deltaTime;
                }
                else if (outTimer < fadeTime && outTimer > 0f)
                {
                    outTimer -= Time.deltaTime;
                }
                else if (outTimer <= 0f)
                {
                    if (ctIndex <= totalText-1)
                    {
                        ctIndex++;
                        fadeOut = false;
                        fadeIn = true;
                        outTimer = fadeTime;
                    }
                    else
                    {
                        trigger = false;
                        end();
                    }
                }
            }
            if (fadeIn)
            {
                if (inTimer == fadeTime)
                {
                    fadeInCall();
                    inTimer -= Time.deltaTime;
                }
                else if (inTimer < fadeTime && inTimer > 0f)
                {
                    inTimer -= Time.deltaTime;
                }
                else if (inTimer <= 0f)
                {
                    fadeOut = true;
                    fadeIn = false;
                    inTimer = fadeTime;
                }
            }

        }

    }

        

    
    public void fadeOutCall()
    {
        StartCoroutine(fadeOutRoutine());
    }

    private IEnumerator fadeOutRoutine()
    {
        Color originalColor = allCreditText[ctIndex].color;
        for (float t = 0.01f; t < fadeTime; t += Time.deltaTime)
        {
            allCreditText[ctIndex].color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t/fadeTime));
            yield return null;
        }
    }

    public void fadeInCall()
    {
        StartCoroutine(fadeInRoutine());
    }


    private IEnumerator fadeInRoutine()
    {
        Color originalColor = allCreditText[ctIndex].color;
        for (float t = 0.01f; t < fadeTime; t += Time.deltaTime)
        {
            allCreditText[ctIndex].color = Color.Lerp(originalColor, Color.white, Mathf.Min(1, t/fadeTime));
            yield return null;
        }
    }


}