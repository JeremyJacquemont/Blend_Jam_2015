using UnityEngine;
using System.Collections;

public class Invicibility : BasePowerUps {

	public int duration = 5;

	public Invicibility(Game g, int value) : base(g){
		this.duration = value;
	}

	public Invicibility(Game g):base(g){}

	#region implemented abstract members of BasePowerUps
	public override void OnTriggerEnter (Collider other)
	{
		if (isTriggering)
			return;
		
		isTriggering = true;
		if (other == null)
			return;
		Vehicle v = other.gameObject.GetComponent<Vehicle>();
		
		if (v == null)
			return;
		v.Fly (duration);
	}
	#endregion
	
}
