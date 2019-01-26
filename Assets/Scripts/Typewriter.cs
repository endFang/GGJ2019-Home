using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour
{
	public float startDelay;
	public float interval = 0.1f;
	public float endDelay;

	public UnityEvent onEnd;

	private IEnumerator Start()
	{
		var textComponent = GetComponent<Text>();
		
		string originalText = textComponent.text;
		textComponent.text = "";

		yield return new WaitForSeconds(startDelay);

		foreach (char c in originalText)
		{
			textComponent.text += c;
			yield return new WaitForSeconds(interval);
		}

		yield return new WaitForSeconds(endDelay);

		onEnd.Invoke();
	}
}