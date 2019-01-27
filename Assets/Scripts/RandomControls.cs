using UnityEngine;

public class RandomControls : MonoBehaviour
{
	public bool enableInEditor;

	// MHHT = Mean Time To Happen. The probability that controls get randomized is influenced by this.
	public float mtth = 10;

	private PlayerMove move;
	private PlayerJump jump;
	private PlayerAttack attack;

	private void Start()
	{
		if (Application.isEditor && !enableInEditor)
		{
			enabled = false;
			return;
		}

		move = GetComponent<PlayerMove>();
		jump = GetComponent<PlayerJump>();
		attack = GetComponent<PlayerAttack>();
	}

	private void FixedUpdate()
	{
		float chance = Time.fixedDeltaTime / mtth;

		if (Random.value < chance)
		{
			FlipHorizontal();
		}

		if (Random.value < chance)
		{
			FlipFireAndJump();
		}
	}

	private void FlipHorizontal()
	{
		move.moveSpeed = -move.moveSpeed;
	}

	private void FlipFireAndJump()
	{
		KeyCode jumpKey = jump.keybind;
		jump.keybind = attack.keybind;
		attack.keybind = jumpKey;
	}
}