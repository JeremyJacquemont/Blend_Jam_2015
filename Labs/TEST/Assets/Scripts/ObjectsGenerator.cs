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
	
	public MoveObject CreateObject(Vector3 offset)
	{
//		moveObjects
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
