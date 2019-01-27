using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
	public static Timer instance;
	private bool duplicate;

	private float timeElapsed;
	private TextMeshProUGUI tmpg;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		timeElapsed = PlayerPrefs.HasKey("Timer") ? PlayerPrefs.GetFloat("Timer") : 0.0f;
		tmpg = GetComponent<TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update()
	{
		timeElapsed += Time.deltaTime;

		string minutes = Mathf.Floor(timeElapsed / 60).ToString("00");
		string seconds = (timeElapsed % 60).ToString("00");

		tmpg.text = $"Timer: {minutes}:{seconds}";
	}

	public void ClearTimer()
	{
		PlayerPrefs.DeleteKey("Timer");
		timeElapsed = 0;
	}

	private void OnDestroy()
	{
		if (instance != this) return;
		PlayerPrefs.SetFloat("Timer", timeElapsed);
	}
}