using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public Cardboard cardboard;

	void Update() {
		if (cardboard.TapIsTrigger) 
			Application.LoadLevelAsync ("gameScene");
	}
}
 