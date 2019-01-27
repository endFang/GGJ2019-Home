using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public enum PlayerKey
{
	Circle,
	Square,
}

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	private int keyBits;
	public UnityEvent afterCollectKey;

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

	public bool HasKey(PlayerKey key)
	{
		return (keyBits & (1 << (int) key)) != 0;
	}

	public void AddKey(PlayerKey key)
	{
		keyBits |= 1 << (int) key;
		afterCollectKey.Invoke();
	}
}