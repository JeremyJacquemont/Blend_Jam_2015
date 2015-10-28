using UnityEngine;
using System.Collections;

public abstract class BasePowerUps : MonoBehaviour {

	protected Game game;

	protected bool isTriggering = false;

	public abstract void OnTriggerEnter (Collider other) ;

	public BasePowerUps(Game g){
		game = g;
	}
	
	public void OnTriggerExit(Collider other){
		isTriggering = false;
	}
}
