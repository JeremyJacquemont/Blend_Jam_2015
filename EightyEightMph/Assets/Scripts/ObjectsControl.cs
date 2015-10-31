using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectsControl : MonoBehaviour {
	
	public ObjectsGenerator objectGenerator;
	
	public Transform back;
	public Transform top;
	public Transform front;

	private Vector3 backPos;
	private Vector3 topPos;
	private Vector3 frontPos;

	public float limitLeft = -10f;
	public float limitRight = 10f;
	private float roadSize;
	
	private float time = 0f;
	
	public float lastSolidGenerated;
	public float lastRetarderGenerated;
	public float lastFailerGenerated;

	public List<MoveObject> moveObjects;
	public List<MoveObject> toRemoveMoveObjects;

	public List<BaseObstacle> obstacles;
	public List<BasePowerUps> powerUps;

	public bool isShocking = false;

	// Use this for initialization
	void Start () {
		
		backPos = back.position;
		topPos = top.position;
		frontPos = front.position;

		// Init 
		if (moveObjects == null)
		{
			moveObjects = new List<MoveObject>();
		} else {
			// Init already present objects
			foreach (MoveObject obj in moveObjects)
			{
				SetupMoveObject(obj, 0f);
			}
		}
		toRemoveMoveObjects = new List<MoveObject>();

		// Road Size
		roadSize = (Mathf.Abs(limitLeft) + Mathf.Abs(limitRight));
	}
	
	public void SetupMoveObject(MoveObject obj, float carX)
	{

		float offset = (Random.value * (float)roadSize) - ((float)roadSize*0.5f);

		obj.offset = new Vector3( offset, 0.25f, 0f);
//		Debug.Log ("Offset : " + obj.offset);

		
		// Beacons
		obj.ConfigBeacons(
			frontPos,
			topPos,
			backPos,
			carX
		);
	}

	public void SetupDecorObject(MoveObject obj, float carX)
	{
		int side = Mathf.Round (Random.value) == 0 ? 1 : - 1;

		obj.offset = new Vector3( (Random.value * 7f * side) + (7f * side *2), 0f, 0f);

		// Beacons
		obj.ConfigBeacons(
			frontPos,
			topPos,
			backPos,
			carX
			);
	}
	
	public void UpdateObjects(int level, float deltaTime, float speed)
	{
		time += deltaTime;
		
		// Generate Objects
		
		
		// Update Objects
		foreach (MoveObject obj in moveObjects)
		{
			UpdateObject(obj, deltaTime, speed);

			if (obj.time > 2f)
			{	
				moveObjects[moveObjects.IndexOf(obj)] = null;
				Destroy(obj.gameObject);
			}
		}

		moveObjects.RemoveAll((o)=>o == null);

	}
	
	public void UpdateObject(MoveObject obj, float deltaTime, float speed)
	{
		obj.UpdateTime(deltaTime, speed);
	}

	public void GenerateRandomObject(float carX)
	{

		MoveObject obj = objectGenerator.CreateObject();
		if (obj == null)
			return;

		if (isShocking) {
			obj.gameObject.GetComponentInChildren<BaseObstacle>().DownObstacle();
		}

		moveObjects.Add(obj);

		SetupMoveObject(obj, carX);
	}

	public void GenerateBonusObject(float carX)
	{
		MoveObject obj = objectGenerator.CreateObject("bonus",0);
		if (obj == null)
			return;

		obj.gameObject.GetComponentInChildren<BasePowerUps> ().game = this.gameObject.GetComponentInParent<Game> ();
		moveObjects.Add(obj);
		
		SetupMoveObject(obj, carX);
	}

	public void GenerateDecorObject(float carX,int level)
	{
		MoveObject obj = objectGenerator.CreateObject("decor",level);
		if (obj == null)
			return;

		moveObjects.Add(obj);
		
		SetupDecorObject(obj, carX); 
	}


	public void ShockObstacles ()
	{
		foreach (MoveObject obj in moveObjects) {
			BaseObstacle obs = obj.gameObject.GetComponentInChildren<BaseObstacle>();
			if(obs != null){
				obs.DownObstacle();
			}
		}
	}
}
