using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour
{
	private Text text;

	public float startDelay;
	public float interval;
	public float endDelay;

	public UnityEvent onEnd;

	private IEnumerator Start()
	{
		string originalText = text.text;
		text.text = "";

		yield return new WaitForSeconds(startDelay);

		foreach (char c in originalText)
		{
			text.text += c;
			yield return new WaitForSeconds(interval);
		}

		yield return new WaitForSeconds(endDelay);

		onEnd.Invoke();
	}
}