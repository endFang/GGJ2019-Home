using UnityEngine;

public class WinTheGame : MonoBehaviour
{
	public GameObject winText;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Player") && GameObject.Find("Enemy(Clone)") == null)
		{
			Victory();
		}
	}

	void Victory()
	{
		winText.SetActive(true);
		Time.timeScale = 0;
		Timer.instance.ClearTimer();
	}
}