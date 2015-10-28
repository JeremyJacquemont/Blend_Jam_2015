using UnityEngine;
using System.Collections;

public class Invicibility : BasePowerUps {
	#region implemented abstract members of BasePowerUps
	public override void OnTriggerEnter (Collider other)
	{
		throw new System.NotImplementedException ();
	}
	#endregion
	
}
