using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {
	Vector3 init;

	private bool isFlying = false;

	public Game game;

	// Use this for initialization
	void Start () {
		init = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
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
		if(transform.position.y > init.y)
			transform.Translate(- Vector3.up * Time.deltaTime * 5);
		if(transform.position.y < init.y)
		{
			Vector3 v = transform.position;
			v.y = init.y;
			transform.position = v;
		}
	}

	public void HitFixedObstacle ()
	{
		Debug.Log ("Fixed obstacle");
		game.StopGame ();
	}

	public void HitEffectObstacle (float value, EffectType type)
	{
		Debug.Log ("Effect " + value.ToString()+ " " + type.ToString());
	}

	public void HitHeavyObstacle (int value)
	{
		game.car.SetSpeed (game.car.currentSpeed - value);
		if (game.car.currentSpeed < 20)
			game.car.SetSpeed (20);
	}

	public void HitLightObstacle (int value)
	{
		game.car.SetSpeed (game.car.currentSpeed - value);
		if (game.car.currentSpeed < 20)
			game.car.SetSpeed (20);
	}

	public void Accelerate(int value){
		game.car.SetSpeed (game.car.currentSpeed + value);
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
