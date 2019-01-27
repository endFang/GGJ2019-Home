using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
	private float timeElapsed;
	private TextMeshProUGUI tmpg;

    // Start is called before the first frame update
    void Start()
    {
		timeElapsed = 0.0f;
        tmpg = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
		timeElapsed += Time.deltaTime;

		string minutes = Mathf.Floor(timeElapsed / 60).ToString("00");
		string seconds = (timeElapsed % 60).ToString("00");

		tmpg.text = string.Format("Timer: {0}:{1}", minutes, seconds);
        
    }
}
