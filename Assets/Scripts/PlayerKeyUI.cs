using UnityEngine;

public class PlayerKeyUI : MonoBehaviour
{
	public GameObject circleKey;
	public GameObject squareKey;

	private void Start()
	{
		GameManager.instance.afterCollectKey.AddListener(RenderKeys);
		RenderKeys();
	}

	private void RenderKeys()
	{
		circleKey.SetActive(GameManager.instance.HasKey(PlayerKey.Circle));
		squareKey.SetActive(GameManager.instance.HasKey(PlayerKey.Square));
	}

	private void OnDestroy()
	{
		GameManager.instance.afterCollectKey.RemoveListener(RenderKeys);
	}
}