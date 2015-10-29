using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class Score : MonoBehaviour {

	public string id;
	public float score;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	public void InitScore()
	{
//		id = GetUniqueKey();
	}

	public void SetScore(float points)
	{
		score = points;
	}

	public void AddPoints(float points)
	{
		score += points;
		Debug.Log ("score : " + score);
	}

//	public void RemovePoints(float points)
//	{
////		score -= points;
////		if (score)
////		Debug.Log ("score : " + score);
//	}

	public void ResetScore()
	{
		score = 0f; 
	}

	public void ProcessScoreBySpeed(float mph, float deltaTime)
	{
		float fact = 1f;

		if (fact>50 && fact<=59)
		{
			fact = 1.1f;
		} else if (fact>60 && fact<=67)
		{
			fact = 1.2f;
		} else if (fact>68 && fact<=74)
		{
			fact = 1.3f;
		} else if (fact>75 && fact<=79)
		{
			fact = 1.4f;
		} else if (fact>80 && fact<=87)
		{
			fact = 1.5f;
		} else if (fact>88 && fact<=90)
		{
			fact = 2.0f;
		} else 
		{
			fact = 1f;
		}

		float pts = fact * mph * deltaTime;

		AddPoints(pts);
	}
}
