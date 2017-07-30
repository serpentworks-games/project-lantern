using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;

	Vector3 offset;

	void Start()
	{
		offset = transform.position - target.position;
	}

	void Update(){
		Vector3 targetCamPos = target.position + offset;
		transform.position = targetCamPos;
	}
}
