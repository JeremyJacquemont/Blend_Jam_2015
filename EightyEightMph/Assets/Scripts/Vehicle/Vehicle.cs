using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {
	Vector3 init;

	public bool isInvinsible = false;

	public Game game;

	// Use this for initialization
	void Start () {
		init = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

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
		game.isInvincible = true;
		StartCoroutine(StopFlying(duration));
	}

	private IEnumerator StopFlying(float duration){
		yield return new WaitForSeconds(duration);
		game.isInvincible = false;
		Debug.Log ("End Flying");
	}
}
