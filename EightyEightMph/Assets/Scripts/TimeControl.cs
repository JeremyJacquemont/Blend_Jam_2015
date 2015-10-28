using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour {

	public float time;
	public float deltaTime;
	public float timeScale;

	// Use this for initialization
	void Start () {
		time = 0f;
		timeScale = 1f;
	}

	public void SetTimeScale(float timeScale)
	{
		this.timeScale = timeScale;
	}

	// Update is called once per frame
	public float UpdateTimer(float deltaTime) {

		this.deltaTime = deltaTime * timeScale;
		time += deltaTime * timeScale;

		return time;
	}
}
