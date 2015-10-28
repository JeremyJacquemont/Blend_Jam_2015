using UnityEngine;
using System.Collections;

public class ShockWave : BasePowerUps {

	public float duration = 10;

	public ShockWave(Game g):base(g){}

	public ShockWave(Game g, float value) : base(g){
		this.duration = value;
	}

	#region implemented abstract members of BasePowerUps
	public override void OnTriggerEnter (Collider other)
	{
		if (isTriggering)
			return;
		
		isTriggering = true;
		if (other == null)
			return;

		game.ShockObstacles (duration);
	}
	#endregion
}