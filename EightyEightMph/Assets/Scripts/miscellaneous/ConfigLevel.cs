using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConfigLevel : MonoBehaviour {

	public Material skybox;
	public GameObject floor;
	public GameObject sun;

	public float minX;
	public float maxX;

	public List<int> Accelerator;
	public List<int> ShockWave;
	public List<int> Invincibility;
	public List<int> SlowMotion;

	public List<float> Obstacles;
}
 