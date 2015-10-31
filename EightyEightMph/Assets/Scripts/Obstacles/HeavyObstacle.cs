using UnityEngine;
using System.Collections;

public class HeavyObstacle : BaseObstacle {

	[Range (10, 50)]
	public int value = 5;

	public override void OnTriggerEnter(Collider other){
		if (isTriggering)
			return;
		
		isTriggering = true;
		if (other == null)
			return;
		Vehicle v = other.gameObject.GetComponent<Vehicle>();
		
		if (v == null || v.isInvinsible)
			return;

		v.HitHeavyObstacle (value);
	}
}
