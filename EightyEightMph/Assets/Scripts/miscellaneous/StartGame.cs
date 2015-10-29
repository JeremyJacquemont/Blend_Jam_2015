using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	
	void Update() {
		if (Cardboard.SDK.TapIsTrigger) 
			Application.LoadLevelAsync ("gameScene");
	}
}
 