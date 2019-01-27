using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class KeyProviderTrigger : MonoBehaviour
{
	public PlayerKey key;

	public UnityEvent afterGiveKey;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.gameObject.CompareTag("Player")) return;

		GameManager.instance.AddKey(key);
		afterGiveKey.Invoke();
	}

	public void SelfDestruct()
	{
		Destroy(gameObject);
	}
}