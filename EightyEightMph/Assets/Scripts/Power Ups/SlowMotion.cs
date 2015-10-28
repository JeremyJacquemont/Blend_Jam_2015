using UnityEngine;
using System.Collections;

public class SlowMotion : BasePowerUps {

	public float value = 5;

	public float duration = 5f;

	public SlowMotion(Game g):base(g){}

	public SlowMotion(Game g, float duration, float value):base(g){
		this.duration = duration;
		this.value = value;
	}

	#region implemented abstract members of BasePowerUps
	public override void OnTriggerEnter (Collider other)
	{
		if (isTriggering)
			return;
		
		isTriggering = true;
		if (other == null)
			return;
		
		game.SlowTime (duration, value);
	}
	#endregion
	
}
