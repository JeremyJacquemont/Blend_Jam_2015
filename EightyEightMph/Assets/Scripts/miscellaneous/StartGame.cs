using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public Cardboard cardboard;

	private bool isStarting;

	void Start(){
		cardboard.VRModeEnabled = GlobalParameters.isVREnabled;
	}

	void Update() {
		if (cardboard.Triggered && !isStarting) {
			isStarting = true;
			Application.LoadLevel ("gameScene");
			Destroy (cardboard);
		}
	}
}
 