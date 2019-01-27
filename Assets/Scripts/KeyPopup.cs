using System.Collections;
using UnityEngine;

public class KeyPopup : MonoBehaviour
{
	public void DisplayPopup()
	{
		StartCoroutine(DisplayPopupCoroutine());
	}

	private IEnumerator DisplayPopupCoroutine()
	{
		float startTime = Time.time;
		RectTransform rt = GetComponent<RectTransform>();

		while (Time.time - startTime < 1)
		{
			yield return null;
			rt.pivot = new Vector2(rt.pivot.x, Mathf.Lerp(0.5f, 0, Time.time - startTime));
		}

		yield return new WaitForSeconds(1);

		startTime = Time.time;

		while (Time.time - startTime < 1)
		{
			yield return null;
			rt.pivot = new Vector2(rt.pivot.x, Mathf.Lerp(0, 0.5f, Time.time - startTime));
		}
	}
}