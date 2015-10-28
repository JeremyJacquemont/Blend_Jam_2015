using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {
	Vector3 init;

	// Use this for initialization
	void Start () {
		init = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward);
	}

	public void HitSolidObstacle(){
		Debug.Log ("Solid obstacle");
	}

	public void HitRetarder(int value){
		Debug.Log ("Retarder " + value.ToString());
	}

	public void HitFailer(float duration){
		Debug.Log ("Failer " + duration.ToString());
	}
}
