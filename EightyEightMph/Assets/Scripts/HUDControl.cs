using UnityEngine;
using System.Collections;

public class HUDControl : MonoBehaviour {

	public Transform t;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<RectTransform> ().rotation = t.rotation;
	}
}
