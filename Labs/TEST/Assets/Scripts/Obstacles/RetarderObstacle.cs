using UnityEngine;
using System.Collections;

public class RetarderObstacle : BaseObstacle {

	public int value = 5;

	public override void OnTriggerEnter(Collider other){
		if (isTriggering)
			return;
		
		isTriggering = true;
		if (other == null)
			return;
		Vehicle v = other.gameObject.GetComponent<Vehicle>();
		
		if (v == null)
			return;

		DownObstacle ();
		v.HitRetarder (value);
	}
}
