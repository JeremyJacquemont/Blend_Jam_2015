using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	public Score score;

	public Text idText;
	public Text scoreText;

	public bool scoring = false;
	
	public Cardboard cartboard;

	private bool isStarting;

	void Start(){ 

		cartboard = GameObject.Find ("CardboardMain").GetComponent<Cardboard> ();
		Destroy (GameObject.Find ("Lotus"));
	}
		
		void Update()
	{

		score = GameObject.Find ("Score").GetComponent<Score> ();
		if (score != null && !string.IsNullOrEmpty(score.id)) {
			idText.text = score.id;
			scoreText.text = score.score.ToString ();

			if (cartboard.Triggered && !isStarting) {
				isStarting = true;
				Application.LoadLevelAsync ("gameScene");
			}
		}
	}
}