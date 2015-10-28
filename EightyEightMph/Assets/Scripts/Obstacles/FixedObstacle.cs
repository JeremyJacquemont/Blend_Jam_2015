using UnityEngine;
using System.Collections;

public class FixedObstacle : BaseObstacle {

	public override void OnTriggerEnter(Collider other){
		if (isTriggering)
			return;
		
		isTriggering = true;
		if (other == null)
			return;
		Vehicle v = other.gameObject.GetComponent<Vehicle>();
		
		if (v == null)
			return;
		v.HitFixedObstacle ();
	}
}
