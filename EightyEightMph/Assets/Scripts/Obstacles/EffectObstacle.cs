using UnityEngine;
using System.Collections;

public class EffectObstacle : BaseObstacle {

	public float duration = 10;

	public EffectType type;

	public EffectObstacle(EffectType t){
		this.type = t;
		if (t == EffectType.popper)
			FullSize ();
	}

	void Start(){
		if (type == EffectType.popper)
			FullSize ();
	}

	private void FullSize(){
		Vector3 size = new Vector3(20,1,20);
		this.GetComponent<BoxCollider> ().size = size;
	}

	public override void OnTriggerEnter(Collider other){
		if (isTriggering)
			return;
		
		isTriggering = true;
		if (other == null)
			return;
		Vehicle v = other.gameObject.GetComponent<Vehicle>();
		
		if (v == null)
			return;
		v.HitEffectObstacle (duration, type);
	}
	
	public override void DownObstacle(){
		
	}
}
