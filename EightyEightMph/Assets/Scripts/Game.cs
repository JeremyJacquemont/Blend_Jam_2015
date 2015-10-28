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

		InvokeRepeating("GenerateRandomObject", 5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update() {
		UpdateGame();

		Test();
	}

	void UpdateGame()
	{
		timer.UpdateTimer(Time.deltaTime);
		deltaTime = timer.deltaTime;

		objectsControl.UpdateObjects(level, deltaTime);
	}

	public void levelUp()
	{
		level += 1;
	}




	public void Test()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GenerateRandomObject();
		}
	}

	public void GenerateRandomObject()
	{
		objectsControl.GenerateRandomObject();
	}
}
