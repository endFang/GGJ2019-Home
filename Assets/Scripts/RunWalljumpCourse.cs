using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;

public class RunWalljumpCourse : MonoBehaviour
{
	public bool devMode;

	private Rigidbody2D rb2d;

	private void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		if (!Application.isEditor || !devMode) return;
		Invoke(nameof(RunCourse), 10);
	}

	public void RunCourse()
	{
		StartCoroutine(RunCourseCoroutine());
	}

	private IEnumerator RunCourseCoroutine()
	{
		GameObject player = GameObject.FindWithTag("Player");

		float moveSpeed = Mathf.Abs(player.GetComponent<PlayerMove>().moveSpeed);
		float jumpStrength = player.GetComponent<PlayerJump>().jumpStrength;
		
		yield return new WaitForSeconds(0.1f);
		// Starting position
		Coroutine move = StartCoroutine(SetHorizontalMove(-moveSpeed));
		yield return new WaitForSeconds(0.1f);
		Jump(jumpStrength);
		yield return new WaitForSeconds(0.6f);
		StopCoroutine(move);
		move = StartCoroutine(SetHorizontalMove(moveSpeed));
		Jump(jumpStrength);
		yield return new WaitForSeconds(0.8f);
		StopCoroutine(move);
		Stop();
		yield return new WaitForSeconds(0.25f);
		// At first platform
		move = StartCoroutine(SetHorizontalMove(-moveSpeed));
		yield return new WaitForSeconds(0.2f);
		Jump(jumpStrength);
		yield return new WaitForSeconds(0.6f);
		StopCoroutine(move);
		move = StartCoroutine(SetHorizontalMove(moveSpeed));
		Jump(jumpStrength);
		yield return new WaitForSeconds(0.8f);
		StopCoroutine(move);
		Stop();
		yield return new WaitForSeconds(0.5f);
		// At second platform
		move = StartCoroutine(SetHorizontalMove(-moveSpeed));
		yield return new WaitForSeconds(0.2f);
		Jump(jumpStrength);
		yield return new WaitForSeconds(0.6f);
		StopCoroutine(move);
		move = StartCoroutine(SetHorizontalMove(moveSpeed));
		Jump(jumpStrength);
		// At third platform
		yield return new WaitForSeconds(1.2f);
		Jump(jumpStrength);
		yield return new WaitForSeconds(0.5f);
		StopCoroutine(move);
		Stop();
		
		Destroy(gameObject);
	}

	private void Jump(float strength)
	{
		rb2d.AddForce(Vector2.up * strength, ForceMode2D.Impulse);
	}

	private IEnumerator SetHorizontalMove(float move)
	{
		while (true)
		{
			rb2d.velocity = new Vector2(move, rb2d.velocity.y);
			yield return null;
		}
	}

	private void Stop()
	{
		rb2d.velocity = new Vector2(0, rb2d.velocity.y);
	}
}