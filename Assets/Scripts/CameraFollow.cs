using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform player;
	public float cameraSpeed = .0125f;
	public Vector3 offset;
	

    void LateUpdate()
    {
		transform.position = Vector3.Lerp(transform.position, player.position + offset, cameraSpeed * Time.deltaTime);
    }
}
