using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public Cardboard cartboard;

	private bool isStarting;
	void Update() {
		if (cartboard.Triggered && !isStarting) {
			isStarting = true;
			Application.LoadLevelAsync ("gameScene");
		}
	}
}
 