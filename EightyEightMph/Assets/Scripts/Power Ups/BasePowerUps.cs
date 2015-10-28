using UnityEngine;
using System.Collections;

public abstract class BasePowerUps : MonoBehaviour {

	protected bool isTriggering = false;

	public abstract void OnTriggerEnter (Collider other) ;
	
	public void OnTriggerExit(Collider other){
		isTriggering = false;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
