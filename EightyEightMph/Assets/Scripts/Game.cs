using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public TimeControl timer;
	public ObjectsControl objectsControl;

	public int level = 1;

	// Process
	float deltaTime = 0f;

	void Awake() {
		if (timer == null) {
			Debug.Log("NO TIMER !!!");
		}
	}

	// Use this for initialization
	void Start () {
		timer.SetTimeScale(1f);
	}
	
	// Update is called once per frame
	void Update() {
		UpdatGame();
	}

	void UpdatGame()
	{
		timer.UpdateTimer(Time.deltaTime);
		deltaTime = timer.deltaTime;

		objectsControl.UpdateObjects(level, deltaTime);
	}

	public void levelUp()
	{
		level += 1;
	}

	public void ShockObstacles (float duration)
	{
		objectsControl.ShockObstacles ();
		objectsControl.isShocking = true;
		Debug.Log ("Start shocking");
		StartCoroutine(StopShocking(duration));
	}

	private IEnumerator StopShocking(float duration){
		yield return new WaitForSeconds(duration);
		objectsControl.isShocking = false;
		Debug.Log ("End shocking");
	}

	public void SlowTime (float duration, float value)
	{
		timer.SetTimeScale (value);
		Debug.Log ("Start slowing");
		StartCoroutine(StopSlowTime(duration));
	}

	private IEnumerator StopSlowTime(float duration){
		yield return new WaitForSeconds(duration);
		timer.SetTimeScale (1f);
		Debug.Log ("End shocking");
	}
}
