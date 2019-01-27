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
		tmpg.text = string.Format("Timer: {0:0.00}", timeElapsed);
        
    }
}
