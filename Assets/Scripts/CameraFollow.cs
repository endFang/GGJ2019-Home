using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform player;

    void Start()
    {
        transform.position = player.transform.position;
    }


    void LateUpdate()
    {
        transform.position = player.transform.position;
    }
}   
