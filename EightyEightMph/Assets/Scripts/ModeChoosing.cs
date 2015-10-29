using UnityEngine;
using System.Collections;

public class ModeChoosing : MonoBehaviour {

	public void StartWithVR(){
		GlobalParameters.isVREnabled = true;
		Application.LoadLevel ("menuScene");
	}

	public void StartWithOutVR(){
		GlobalParameters.isVREnabled = false;
		Application.LoadLevel ("menuScene");
	}
}
