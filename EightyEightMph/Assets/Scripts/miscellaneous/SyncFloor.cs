using UnityEngine;
using System.Collections;

public class SyncFloor : MonoBehaviour {

	private Transform myTransform;
	public Transform target;

	private Vector3 position;

	// Use this for initialization
	void Awake () {
		myTransform = transform;

		position = myTransform.position;
	}

	void Start()
	{
		target = GameObject.Find("Car").transform;
	}
	
	// Update is called once per frame
	void Update () {
		position.x = target.position.x;
		myTransform.position = position;
	}
}
