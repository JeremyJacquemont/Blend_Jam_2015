using UnityEngine;
using System.Collections;

public class SoundObstacle : MonoBehaviour {

	public AudioSource audio;

	public void SetVolume(float distance) {
//		Debug.Log (1 / distance);
//
//		audio.volume = 1 / Mathf.Pow (distance, 2);
//
//		Debug.Log (1 / Mathf.Pow (distance, 2));

		audio.volume = Mathf.Cos (distance * distance) * 2f;
	}
}
