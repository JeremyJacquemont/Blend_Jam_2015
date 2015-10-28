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

	public float limitLeft = -7f;
	public float limitRight = 7f;
	private float roadSize;
	
	private float time = 0f;
	
	public float lastSolidGenerated;
	public float lastRetarderGenerated;
	public float lastFailerGenerated;
	
	
	public List<MoveObject> moveObjects;
	
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
				SetupMoveObject(obj);
			}
		}

		// Road Size
		roadSize = (Mathf.Abs(limitLeft) + Mathf.Abs(limitRight));
	}
	
	public void SetupMoveObject(MoveObject obj)
	{


		obj.offset = new Vector3( (Random.value * (float)roadSize) - ((float)roadSize*0.5f), 0f, 0f);
		Debug.Log ("Offset : " + obj.offset);
		// Beacons
		obj.ConfigBeacons(
			frontPos,
			topPos,
			backPos
		);

	}
	
	public void UpdateObjects(int level, float deltaTime)
	{
		time += deltaTime;
		
		// Generate Objects
		
		
		// Update Objects
		foreach (MoveObject obj in moveObjects)
		{
			UpdateObject(obj, deltaTime);
		}
	}
	
	public void UpdateObject(MoveObject obj, float deltaTime)
	{
		obj.UpdateTime(deltaTime);
	}

	public void GenerateRandomObject()
	{
		MoveObject obj = objectGenerator.CreateObject();

		moveObjects.Add(obj);

		SetupMoveObject(obj);


	}
}
