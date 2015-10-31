using UnityEngine;
using System.Collections;

public class LightObstacle : BaseObstacle {

	[Range (0, 10)]
	public int value;

	public override void OnTriggerEnter(Collider other){
		if (isTriggering)
			return;
		
		isTriggering = true;
		if (other == null)
			return;
		Vehicle v = other.gameObject.GetComponent<Vehicle>();
		
		if (v == null || v.isInvinsible)
			return;

		DownObstacle ();
		v.HitLightObstacle (value);
	}
}
