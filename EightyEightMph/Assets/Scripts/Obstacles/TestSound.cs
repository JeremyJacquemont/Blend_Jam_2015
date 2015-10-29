using UnityEngine;
using System.Collections;

public class TestSound : MonoBehaviour {

	[Range(0.00001f,1)]
	public float distance;

	public SoundObstacle target;

	void Update () {
		target.SetVolume (distance);
	}
}
