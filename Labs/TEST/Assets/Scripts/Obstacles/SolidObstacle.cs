using UnityEngine;
using System.Collections;

public class SolidObstacle : BaseObstacle {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnTriggerEnter(Collider other){
		if (isTriggering)
			return;

		isTriggering = true;
		if (other == null)
			return;
		Vehicle v = other.gameObject.GetComponent<Vehicle>();

		if (v == null)
			return;
		v.HitSolidObstacle ();
	}
}
