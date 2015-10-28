using UnityEngine;
using System.Collections;

public class EffectObstacle : BaseObstacle {
	
	public float duration = 10;
	
	public override void OnTriggerEnter(Collider other){
		if (isTriggering)
			return;
		
		isTriggering = true;
		if (other == null)
			return;
		Vehicle v = other.gameObject.GetComponent<Vehicle>();
		
		if (v == null)
			return;
		v.HitEffectObstacle (duration);
	}
	
	public override void DownObstacle(){
		
	}
}
