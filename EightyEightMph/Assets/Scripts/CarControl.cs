using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class CarControl : MonoBehaviour {

	Transform myTransform;

	// Cardboard Cam
	public Transform target;

	// Info vehicule
	public Vector3 position;
	// Position du vehicule
	float y;
	float z;

	// Rotation
	public Vector3 rotation;
	public float angle;

	public float MaxX = 66666666f;
	public float MinX = -666666666f;

	public float fact = 1f;

	// Wheel
	public Transform wheel;
	public Vector3 wheelRotation;

	// Speed
	float minSpeed = 20f;
	float maxSpeed = 90f;

	public float currentSpeed = 50f;

	public bool block = false;

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

		angle = target.localRotation.eulerAngles.z;
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

	public void SetSpeed(float speed)
	{
		currentSpeed = speed;
	}

	public void UpdateSpeed(float deltaTime, float accel)
	{
		if (!block) {
			currentSpeed += deltaTime * accel;
		}

		if (currentSpeed > 90f)
		{
			currentSpeed = 90f;
		}
	}
}
