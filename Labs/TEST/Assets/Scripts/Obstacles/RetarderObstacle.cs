using UnityEngine;
using System.Collections;

public class RetarderObstacle : BaseObstacle {
	
	public int goDownSpeed = 1;
	public int value = 5;
	public Transform rotationPoint;

	private bool goDown = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (goDown) {
			this.transform.RotateAround (rotationPoint.position, Vector3.left, -90f * Time.deltaTime * goDownSpeed);
			if(this.transform.rotation.eulerAngles.x >= 90){
				goDown = false;
			}
		}
	}

	public override void OnTriggerEnter(Collider other){
		if (isTriggering)
			return;
		
		isTriggering = true;
		if (other == null)
			return;
		Vehicle v = other.gameObject.GetComponent<Vehicle>();
		
		if (v == null)
			return;

		DownObstacle ();
		v.HitRetarder (value);
	}

	public void DownObstacle(){
		goDown = true;
	}
}
