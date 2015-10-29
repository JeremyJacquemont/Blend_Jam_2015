using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	public enum GameStatus {
		STOP,
		RUNNING
	}

	public GameStatus gameStatus;

	public TimeControl timer;
	public ObjectsControl objectsControl;
	public CarControl car;

	public Text vitesseTimer;

	public int level = 1;
	public LevelInfo levelInfo;

	public float speedFact = 1f;

	public Transform sun;
	public Material sky;
	public Transform roadRoot;

	public List<ConfigLevel> configLevels;

	// Process
	float deltaTime = 0f;

	// Vitesse de défilement
	public float speed = 0f;

	public float miles = 0f;

	void Awake() {
		if (timer == null) {
			Debug.Log("NO TIMER !!!");
		}

		Debug.Log ("Config: " + configLevels.Count);
	}

	// Use this for initialization
	void Start () {

		gameStatus = GameStatus.RUNNING;

		timer.SetTimeScale(1f);

		//InvokeRepeating("GenerateRandomObject", 1f, 0.5f / timer.timeScale);
		//InvokeRepeating("GenerateDecorObject", 0f, 0.5f);
		InvokeRepeating("GenerateBonusObject", 0f, .5f);
	}

	// Update is called once per frame
	void Update() {

		if (gameStatus == GameStatus.RUNNING) {
			UpdateGame();
			UpdateDistance();
		}

		InputTest();

		vitesseTimer.text = car.currentSpeed.ToString ();
	}

	void StartLevel(int levelNumber)
	{
		level = levelNumber;

		levelInfo.ConfigureByLevel(level);

		InitLevel();
	}

	public void StopGame()
	{
		if (gameStatus == GameStatus.RUNNING) {
			gameStatus = GameStatus.STOP;
		}
	}

	public void InitLevel()
	{
		Debug.Log ("Game - Init level: " + level);
		miles = 0f;

		car.InitPosition();
		car.SetSpeed(levelInfo.startSpeed);


		ConfigLevel config = configLevels[(level-1)];

		// Sun
		sun.rotation = config.sun.transform.rotation;

		// Sky
		sky.CopyPropertiesFromMaterial(config.skybox);

		// Road
		Transform roadChild = roadRoot.GetChild(0);
		roadRoot.DetachChildren();
		Destroy(roadChild.gameObject);

		GameObject newRoad = Instantiate(config.floor);
		newRoad.transform.parent = roadRoot;

		// Car
		car.MinX = config.minX;
		car.MaxX = config.maxX;
	}

	void UpdateGame()
	{
		timer.UpdateTimer(Time.deltaTime);
		deltaTime = timer.deltaTime;

		car.UpdateSpeed(timer.deltaTime, levelInfo.accel);

		speed = car.currentSpeed * speedFact * 0.01f;

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



	public void InputTest()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
//			GenerateRandomObject();
			if (gameStatus == GameStatus.STOP) 
			{
				gameStatus = GameStatus.RUNNING;
			}
		}

		if (Input.GetKeyDown(KeyCode.Keypad1))
		{
			StartLevel(1);
		}

		if (Input.GetKeyDown(KeyCode.Keypad2))
		{
			StartLevel(2); 
		}

		if (Input.GetKeyDown(KeyCode.Keypad3))
		{
			StartLevel(3);
		}
	}

	public void GenerateRandomObject()
	{
		if (gameStatus == GameStatus.RUNNING) { 
			objectsControl.GenerateRandomObject(car.transform.position.x);
		}
	}

	public void GenerateDecorObject()
	{
		if (gameStatus == GameStatus.RUNNING) { 
			objectsControl.GenerateDecorObject(car.transform.position.x, level);
		}
	}

	public void GenerateBonusObject()
	{
		if (gameStatus == GameStatus.RUNNING) { 
			objectsControl.GenerateBonusObject(car.transform.position.x);
		}
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
