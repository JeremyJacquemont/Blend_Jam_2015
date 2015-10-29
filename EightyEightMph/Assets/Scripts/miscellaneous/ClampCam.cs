using UnityEngine;
using System.Collections;

public class ClampCam : MonoBehaviour {

	public Transform cam;

	float minY = -50f;
	float maxY = 50f; 

	private Vector3 rot;

	// Use this for initialization
	void Start () {
		rot = cam.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void LateUpdate  () {

//		if (rot.y > 50f && rot.y < 180f)
//		{
//			rot.y = 50f;
//		}

//		cam.rotation = Quaternion.Euler(rot);
	}
}
