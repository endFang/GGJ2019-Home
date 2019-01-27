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

    public float fadeTime;
    public float outTimer;
    public float inTimer;


    public Text[] allCreditText;
    private int totalText;
    private int ctIndex;



    public void Start()
    {
        ctIndex = 0;
        totalText = allCreditText.Length - 1;
        
        inTimer = fadeTime;
        outTimer = fadeTime;
        fadeOut = false;
        fadeIn = true;        
    }


    public void begin()
    {
        gameObject.SetActive(true);
        trigger = true;

        allCreditText[0].enabled = true;
        ctIndex = 0;
        totalText = allCreditText.Length - 1;
        
        inTimer = fadeTime;
        outTimer = fadeTime;
        fadeOut = false;
        fadeIn = true;        
    }

    public void end()
    {
        gameObject.SetActive(false);
    }


    public void Update()
    {
        if (trigger)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                end();
            }

            if (fadeOut)
            {
                if (outTimer == fadeTime)
                {
                    fadeOutCall();
                    outTimer -= Time.deltaTime;
                }
                else if (outTimer < fadeTime && outTimer > -0.5f)
                {
                    outTimer -= Time.deltaTime;
                }
                else if (outTimer <= -0.5f)
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
                else if (inTimer < fadeTime && inTimer > -0.5f)
                {
                    inTimer -= Time.deltaTime;
                }
                else if (inTimer <= -0.5f)
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