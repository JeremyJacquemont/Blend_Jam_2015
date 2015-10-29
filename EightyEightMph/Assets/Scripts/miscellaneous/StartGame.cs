using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	void Update()
	{
		if (Cardboard.SDK.Triggered)
		{
			Application.LoadLevelAsync("gameScene");
		}
	}
}
 