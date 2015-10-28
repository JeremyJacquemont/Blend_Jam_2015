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

	public void HitFixedObstacle ()
	{
		Debug.Log ("Fixed obstacle");
	}

	public void HitEffectObstacle (float value)
	{
		Debug.Log ("Retarder " + value.ToString());
	}

	public void HitHeavyObstacle (int value)
	{
		Debug.Log ("Heavy " + value.ToString());
	}

	public void HitLightObstacle (int value)
	{
		Debug.Log ("Ligth " + value.ToString());
	}

	public void Accelerate(int value){
		Debug.Log ("Accelerate " + value);
	}
}
