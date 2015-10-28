using UnityEngine;
using System.Collections;

public abstract class BaseObstacle : MonoBehaviour {

	protected bool isTriggering = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public abstract void OnTriggerEnter (Collider other) ;

	public void OnTriggerExit(Collider other){
		isTriggering = false;
	}
}
