using UnityEngine;
using System.Collections;

public class LevelInfo : MonoBehaviour {

	public int level = 1;

//	public float minSpeed = 0;
//	public float maxSpeed = 

	public float startSpeed = 20f;
	public float maxSpeed = 90f;
	public float accel = 0.1f;

	public float speedLevelMultiplier = 0.1f;

	public void ConfigureByLevel(int level)
	{
		this.level = level;


	}

	public float GetStartSpeed(int level)
	{
		return startSpeed + level * speedLevelMultiplier;
	}

}
