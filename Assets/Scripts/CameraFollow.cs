using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private float smoothing;
	[SerializeField] private Vector3 offset;
	[SerializeField] private Vector3 velocity;
	[Space]
	[SerializeField] private float clampX = 3.75f;

	void FixedUpdate()
	{
		Vector3 desiredLocation = new Vector3(Mathf.Clamp(target.position.x - offset.x, -clampX, clampX), target.position.y - offset.y, offset.z);
		transform.position = Vector3.SmoothDamp(transform.position, desiredLocation, ref velocity, smoothing);
	}
}
