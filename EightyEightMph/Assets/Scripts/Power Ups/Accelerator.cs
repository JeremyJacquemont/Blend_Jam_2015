using UnityEngine;
using System.Collections;

public class Accelerator : BasePowerUps{

	public int speed = 5;

	public override void OnTriggerEnter(Collider other){
		if (isTriggering)
			return;
		
		isTriggering = true;
		if (other == null)
			return;
		Vehicle v = other.gameObject.GetComponent<Vehicle>();
		
		if (v == null)
			return;
		v.Accelerate (speed);
	}
}
