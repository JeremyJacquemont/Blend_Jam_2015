using UnityEngine;
using System.Collections;

public class GlobalParameters : MonoBehaviour {

	public static bool isVREnabled = true;

	public static void setVREnabled(bool b){
		isVREnabled = b;
	}
}
