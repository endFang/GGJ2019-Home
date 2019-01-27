using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KeyProviderTrigger : MonoBehaviour
{
	public PlayerKey key;
	public GameObject uiPopup;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.gameObject.CompareTag("Player")) return;

		GameManager.instance.AddKey(key);
		
		if (uiPopup != null)
		{
			uiPopup.GetComponent<Image>().StartCoroutine(DisplayPopup());
		}

		Destroy(gameObject);
	}

	private IEnumerator DisplayPopup()
	{
		float startTime = Time.time;
		RectTransform rt = uiPopup.GetComponent<RectTransform>();

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