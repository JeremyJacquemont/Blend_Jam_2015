using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public TimeControl timer;
	public ObjectsControl objectsControl;
	public CarControl car;

	public int level = 1;
	public LevelInfo levelInfo;

	public float speedFact = 1f;

	// Process
	float deltaTime = 0f;

	// Vitesse de défilement
	public float speed = 0f;

	public float miles = 0f;


	void Awake() {
		if (timer == null) {
			Debug.Log("NO TIMER !!!");
		}
	}

	// Use this for initialization
	void Start () {
		timer.SetTimeScale(1f);

		InvokeRepeating("GenerateRandomObject", 1f, 0.5f / timer.timeScale);

		InvokeRepeating("GenerateRandomObject", 0f, 0.5f);

		InvokeRepeating("GenerateDecorObject", 0f, 0.5f);

		InvokeRepeating("GenerateBonusObject", 0f, .5f);
	}

	// Update is called once per frame
	void Update() {
		UpdateGame();

		UpdateDistance();

		Test();
	}

	void StartLevel(int levelNumber)
	{
		level = levelNumber;

		levelInfo.ConfigureByLevel(level);

		InitLevel();
	}

	public void InitLevel()
	{
		miles = 0f;

		car.SetSpeed(levelInfo.startSpeed);
	}

	void UpdateGame()
	{
		timer.UpdateTimer(Time.deltaTime);
		deltaTime = timer.deltaTime;

		car.UpdateSpeed(timer.deltaTime, levelInfo.accel);

		speed = car.currentSpeed * speedFact;

		objectsControl.UpdateObjects(level, deltaTime, speed);
	}

	void UpdateDistance()
	{
		miles = car.currentSpeed * timer.deltaTime;
	}

	public void levelUp()
	{
		level += 1;
		StartLevel(level);
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
		objectsControl.GenerateRandomObject(car.transform.position.x);
	}

	public void GenerateDecorObject()
	{
		objectsControl.GenerateDecorObject(car.transform.position.x);
	}

	public void GenerateBonusObject()
	{
		objectsControl.GenerateBonusObject(car.transform.position.x);
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
