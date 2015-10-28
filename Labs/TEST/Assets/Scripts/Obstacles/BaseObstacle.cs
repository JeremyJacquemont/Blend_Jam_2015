using UnityEngine;
using System.Collections;

public abstract class BaseObstacle : MonoBehaviour {

	public Transform rotationPoint;

	protected bool isTriggering = false;
	
	public abstract void OnTriggerEnter (Collider other) ;

	public void OnTriggerExit(Collider other){
		isTriggering = false;
	}
	
	public virtual void DownObstacle(){
		this.transform.RotateAround (rotationPoint.position, Vector3.left, -90f);
	}
}
