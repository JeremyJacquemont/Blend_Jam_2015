using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectsControl : MonoBehaviour {

	public Transform back;
	public Transform top;
	public Transform front;

	private Vector3 backPos;
	private Vector3 topPos;
	private Vector3 frontPos;

	private float time = 0f;

	public List<MoveObject> moveObjects;

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
				setupMoveObject(obj);
			}
		}
	}
	
	// Update is called once per frame
//	void Update() {
//		UpdateObjects();
//	}

	public void setupMoveObject(MoveObject obj)
	{
		obj.front = frontPos;
		obj.top = topPos;
		obj.back = backPos;
	}

	public void UpdateObjects(int level, float deltaTime)
	{
		time += deltaTime;

		foreach (MoveObject obj in moveObjects)
		{
			UpdateObject(obj, deltaTime);
		}
	}

	public void UpdateObject(MoveObject obj, float deltaTime)
	{
		obj.UpdateTime(deltaTime);
	}

	public void ShockObstacles ()
	{
		foreach (BaseObstacle obstacle in obstacles) {
			obstacle.DownObstacle();
		}
	}
}
