using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;
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

<<<<<<< HEAD
	public Cardboard cardboard;
=======
	public Text vitesseTimer;
>>>>>>> 84f660bbe005e849336030449a89765037a2b67b

	public int level = 1;
	public LevelInfo levelInfo;

	public float speedFact = 1f;

	public Transform sun;
	public Material sky;
	public Transform roadRoot;

	public GoogleAnalyticsV3 googleAnalytics;

	public List<ConfigLevel> configLevels;

<<<<<<< HEAD
	public ConfigLevel current;

	private float timeFromLastCreation;
	int palier = 0;
	float multiplicator = 1f;

	public bool isInvincible = false;
=======
	public Score score;
	public AudioSource audio;

	public AudioClip nextLevelClip;
	public AudioClip crashClip;
>>>>>>> 84f660bbe005e849336030449a89765037a2b67b

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
		StartLevel (1);
		gameStatus = GameStatus.RUNNING;

		timer.SetTimeScale(1f);

		//InvokeRepeating("GenerateRandomObject", 1f, 0.5f / timer.timeScale);
		//InvokeRepeating("GenerateDecorObject", 0f, 0.5f);
		InvokeRepeating("GenerateBonusObject", 0f, .5f);

		googleAnalytics.LogEvent(new EventHitBuilder()
		                          .SetEventCategory("Informations")
		                          .SetEventAction("Start Game"));

		score.InitScore();

	}
	

	// Update is called once per frame
	void Update() {
		 
		if (gameStatus == GameStatus.RUNNING) {
			UpdateGame();
			UpdateDistance();

			if(cardboard.Triggered && car.currentSpeed >= 88 ||  car.currentSpeed >= 88)
				StartLevel(level+1);
		}

		InputTest();

		vitesseTimer.text = car.currentSpeed.ToString ();
	}

	void GeneratePlayableObjects(){
		GenerateObstacle ();

		int r = (int) Random.Range (0, 100);
		Debug.Log (multiplicator.ToString());

		if (r < (current.Accelerator [palier] + current.ShockWave [palier] + current.SlowMotion [palier] + current.Invincibility [palier]) * multiplicator) {
			if (car.currentSpeed < 45) {
				palier = 0;
			}
			else if(car.currentSpeed < 65) {
				palier = 1;
			}
			else if(car.currentSpeed < 80) {
				palier = 2;
			}
			else if(car.currentSpeed < 90) {
				palier = 3;
			}
			GenerateBonus ();
		}
	}

	public void GenerateObstacle()
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
	
	public void GenerateBonus()
	{
		if (gameStatus == GameStatus.RUNNING) { 
			objectsControl.GenerateBonusObject(car.transform.position.x);
		}
	}

	void StartLevel(int levelNumber)
	{
		if (levelNumber > 3) {
			levelNumber = 1;
			multiplicator *= 0.5f;
		}
		level = levelNumber;

		levelInfo.ConfigureByLevel(level);

		InitLevel();

		googleAnalytics.LogEvent(new EventHitBuilder()
		                         .SetEventCategory("Informations")
		                         .SetEventAction("Start Level"));
		audio.clip = nextLevelClip;
		audio.Play();
	}

	public void StopGame()
	{
		if (gameStatus == GameStatus.RUNNING) {
			gameStatus = GameStatus.STOP;


			ParseObject gameScore = new ParseObject("Score");
			gameScore["Score"] = score.score;
			gameScore.SaveAsync ().ContinueWith (t => {
				Debug.Log(gameScore.ObjectId);

				score.id = gameScore.ObjectId;

			});

			Application.LoadLevelAsync("endScene");

			audio.clip = crashClip;
			audio.Play();



		googleAnalytics.LogEvent(new EventHitBuilder()
		                         .SetEventCategory("Informations")
		                         .SetEventAction("Stop Game"));

	}

	public void InitLevel()
	{
		Debug.Log ("Game - Init level: " + level);
		miles = 0f;

		car.InitPosition();
		car.SetSpeed(levelInfo.startSpeed);


		current = configLevels[(level-1)];

		// Sun
			sun.rotation = current.sun.transform.rotation;

		// Sky
			sky.CopyPropertiesFromMaterial(current.skybox);

		// Road
		Transform roadChild = roadRoot.GetChild(0);
		roadRoot.DetachChildren();
		Destroy(roadChild.gameObject);

			GameObject newRoad = Instantiate(current.floor);
		newRoad.transform.parent = roadRoot;

		// Car
			car.MinX = current.minX;
			car.MaxX = current.maxX;
	}

	void UpdateGame()
	{
		if (car.currentSpeed < 45) {
			palier = 0;
		}
		else if(car.currentSpeed < 65) {
			palier = 1;
		}
		else if(car.currentSpeed < 80) {
			palier = 2;
		}
		else if(car.currentSpeed < 90) {
			palier = 3;
		}

		timer.UpdateTimer(Time.deltaTime);
		deltaTime = timer.deltaTime;

		timeFromLastCreation += deltaTime;
		if (timeFromLastCreation > (current.Obstacles [palier] * multiplicator)) {
			timeFromLastCreation = 0;
			GeneratePlayableObjects();
		}

		car.UpdateSpeed(timer.deltaTime, levelInfo.accel);

		speed = car.currentSpeed * speedFact * 0.01f;

		objectsControl.UpdateObjects(level, deltaTime, speed);

		score.ProcessScoreBySpeed(car.currentSpeed, deltaTime);
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

	public void setInvincible(float duration){
		Debug.Log ("Start invincibe");

		isInvincible = true;
	}

	private IEnumerator StopInvincible(float duration){
		yield return new WaitForSeconds(duration);
		Debug.Log ("End invincible");
	}



}
