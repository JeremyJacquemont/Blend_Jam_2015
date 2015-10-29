using UnityEngine;
using System.Collections;
using Parse;

public class ParseScript : MonoBehaviour {

	void Start() {
		ParseScript.SaveScore (37373);
	}

	public static void SaveScore(int score) {

		ParseObject gameScore = new ParseObject("Score");
		gameScore["Score"] = score;
		gameScore.SaveAsync ().ContinueWith (t => {
			Debug.Log(gameScore.ObjectId);
		});

	}

}