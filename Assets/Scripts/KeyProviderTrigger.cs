using UnityEngine;

public class KeyProviderTrigger : MonoBehaviour
{
	public PlayerKey key;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.gameObject.CompareTag("Player")) return;
		
		GameManager.instance.AddKey(key);
		enabled = false;
	}
}