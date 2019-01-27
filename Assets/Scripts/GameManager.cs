using UnityEngine;

public enum UnlockKey
{
	Square,
	Circle,
	Triangle
}

public class GameManager : MonoBehaviour
{
	public GameManager instance;

	private int keyBits;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("Destroying new instance of `GameManager`.");
			Destroy(gameObject);
			return;
		}

		instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public bool HasKey(UnlockKey key)
	{
		return (keyBits & (1 << (int) key)) != 0;
	}

	public void AddKey(UnlockKey key)
	{
		keyBits |= 1 << (int) key;
	}
}