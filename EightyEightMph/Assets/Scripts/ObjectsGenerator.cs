using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ObjectsGenerator : MonoBehaviour {
	
	public Transform objectsRoot;

	public List<MoveObject> moveObjects;

	public ResourcesLib resources;

	public Game game;

	public MoveObject CreateObject()
	{
		List<GameObject> list;
		int r = (int) Math.Round (UnityEngine.Random.Range (0f, 3f));
		if(r == 0)
			list = resources.GetList("heavy", game.level);
		else if(r == 1)
			list = resources.GetList("light", game.level);
		else
			list = resources.GetList("fixed", game.level);

		if (list == null || list.Count == 0)
			return null;

		GameObject moveObjectGO = Instantiate(list[UnityEngine.Random.Range(0,list.Count)]) as GameObject; 
		MoveObject moveObject = moveObjectGO.GetComponent<MoveObject>();
		return moveObject;
	}

	public MoveObject CreateObject(String type, int level)
	{
		List<GameObject> list = resources.GetList(type, level);

		if (list == null)
			return null;

		GameObject moveObjectGO = Instantiate(list[UnityEngine.Random.Range(0,list.Count)]) as GameObject;
		moveObjectGO.transform.parent = objectsRoot;

		MoveObject moveObject = moveObjectGO.GetComponent<MoveObject>();
		return moveObject;
	}

}
