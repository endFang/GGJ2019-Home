using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnImpact : MonoBehaviour
{

	private float timer = 0f;
	private float cooldown = 5f;

	private void Update()
	{
		timer += 1f * Time.deltaTime;
		if (timer > cooldown)
		{
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D _)
	{
		Destroy(gameObject);
	}
}
