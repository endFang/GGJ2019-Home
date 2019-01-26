using UnityEngine;
using UnityEngine.Events;

public class PlayerRespawn : MonoBehaviour
{
	public Vector3 checkpointPosition;

	public UnityEvent afterDeath;
	public UnityEvent afterRespawn;

	private void Start()
	{
		checkpointPosition = transform.position;
	}

	public void Kill()
	{
		gameObject.SetActive(false);
		afterDeath.Invoke();
	}

	public void Respawn()
	{
		transform.position = checkpointPosition;
		gameObject.SetActive(true);
		afterRespawn.Invoke();
	}
}