using UnityEngine;
using System.Collections;

public class Accelerator : BasePowerUps{

	public int speed = 5;

	public Accelerator(Game g):base(g){}

	public Accelerator(Game g, int value) : base(g){
		this.speed = value;
	}

	#region implemented abstract members of BasePowerUps
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
	#endregion
}
