using UnityEngine;
using System.Collections;

public class CarControl : MonoBehaviour {

	Transform myTransform;

	public Transform target;

	public Vector3 rotation;
	public float angle;

	public Vector3 position;

	public float MaxX = 5.5f;
	public float MinX = -5.5f;

	public float fact = 1f;

	float y;
	float z;

	// Wheel
	public Transform wheel;
	public Vector3 wheelRotation;


	// Use this for initialization
	void Awake () {
		myTransform = transform;
		rotation = myTransform.localRotation.eulerAngles;
		y = myTransform.position.y;
		z = myTransform.position.z;

		wheelRotation = wheel.localRotation.eulerAngles;
	}

	// Update is called once per frame
	void Update () {

//		rotation.y = target.localRotation.eulerAngles.y;
//		myTransform.rotation = Quaternion.Euler(rotation);

		angle = target.localRotation.eulerAngles.y;
		if (angle > 180f)
		{
			angle = (360-angle) * -1f;
		}

	

		position += Vector3.right * angle * fact * Time.deltaTime;

		position.x = Mathf.Clamp(position.x, MinX, MaxX);
		position.y = y;
		position.z = z;

		Vector3 rotation = new Vector3(angle, 0f, 0f);
		myTransform.position = position;

		wheelRotation.x = -2f * angle;
		wheel.localRotation = Quaternion.Euler(wheelRotation);
	}
}
