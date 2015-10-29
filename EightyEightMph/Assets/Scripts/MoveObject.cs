using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour
{
	private Transform myTransform;

	public Vector3 position;
	public Vector3 offset;

	public Vector3 back;
	public Vector3 top;
	public Vector3 front;


	[Range (0, 2)]
	public float time;

	public void Awake()
	{
		myTransform = transform; 
	}

	public void ConfigBeacons(Vector3 back, Vector3 top, Vector3 front, float carX)
	{
		this.back = back + offset + Vector3.right * carX;
		this.top = top + offset + Vector3.right * carX;
		this.front = front + offset + Vector3.right * carX;
	}

	// Use this for initialization
	public void UpdateTime(float deltaTime)
	{
		time += deltaTime;
		UpdatePosition();
	}

	private void UpdatePosition()
	{
//		Debug.Log ("HI time is: " + time);

		if (time < 1f)
		{
			position = Vector3.Lerp(back, top, time);
		} else if (time > 1f)
		{
			position = Vector3.Lerp(top, front, time-1f);
		}

		// DEBUG
//		if (time > 3f)
//		{
//			time = -1f;
//		}
	}

	public void Update()
	{
		myTransform.position = position;
	}
}

