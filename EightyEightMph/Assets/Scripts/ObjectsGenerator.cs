using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ObjectsGenerator : MonoBehaviour {
	
	public Transform objectsRoot;

	public List<MoveObject> moveObjects;

	public ResourcesLib resources;

	public MoveObject CreateObject()
	{
		List<GameObject> list;
		if(Math.Round(UnityEngine.Random.value) == 0)
			list = resources.GetList("heavy",1);
		else
			list = resources.GetList("light",1);
		GameObject moveObjectGO = Instantiate(list[UnityEngine.Random.Range(0,list.Count)]) as GameObject; 
		MoveObject moveObject = moveObjectGO.GetComponent<MoveObject>();
		return moveObject;
	}
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
