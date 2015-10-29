using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectsGenerator : MonoBehaviour {
	
	public Transform objectsRoot;
	
	public GameObject moveObjectModel;
	
	public List<MoveObject> moveObjects;
	
	void Awake()
	{
		if (moveObjectModel == null)
		{
			Debug.Log("ObjectGenerator - moveObjectModel null");
		}
	}
	
	public MoveObject CreateObject()
	{
		GameObject moveObjectGO = Instantiate(moveObjectModel);
		MoveObject moveObject = moveObjectGO.GetComponent<MoveObject>();

		return moveObject;
	}

}
