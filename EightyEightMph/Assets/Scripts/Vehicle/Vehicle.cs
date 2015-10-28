using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {
	Vector3 init;

	private bool isFlying = false;

	// Use this for initialization
	void Start () {
		init = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward);

		if (isFlying) {
			Fly ();
		} else {
			Land ();
		}
	}

	private void Fly(){
		if(transform.position.y < 10)
			transform.Translate(Vector3.up * Time.deltaTime * 5);
		if(transform.position.y > 10)
		{
			Vector3 v = transform.position;
			v.y = 10;
			transform.position = v;
		}
	}

	private void Land(){
		if(transform.position.y > 0)
			transform.Translate(- Vector3.up * Time.deltaTime * 5);
		if(transform.position.y < 0)
		{
			Vector3 v = transform.position;
			v.y = 0;
			transform.position = v;
		}
	}


	public void HitFixedObstacle ()
	{
		Debug.Log ("Fixed obstacle");
	}

	public void HitEffectObstacle (float value, EffectType type)
	{
		Debug.Log ("Effect " + value.ToString()+ " " + type.ToString());
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

	public void Fly (int duration)
	{
		Debug.Log ("Fly " + duration.ToString());
		isFlying = true;
		StartCoroutine(StopFlying(duration));
	}

	private IEnumerator StopFlying(float duration){
		yield return new WaitForSeconds(duration);
		isFlying = false;
		Debug.Log ("End Flying");
	}
}
