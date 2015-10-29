using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourcesLib : MonoBehaviour {

	public List<GameObject> Level1LightObstacles;

	public List<GameObject> Level1HeavyObstacles;

	public List<GameObject> Level1FixedObstacles;

	public List<GameObject> Level1EffectObstacles;

	public List<GameObject> Level1Decors;

	private Dictionary<string, List<GameObject>> dico;

	void Start(){
		dico = new Dictionary<string, List<GameObject>> ()
		{
			{"light-1", Level1LightObstacles},
			{"heavy-1", Level1HeavyObstacles},
			{"fixed-1", Level1FixedObstacles},
			{"effect-1", Level1EffectObstacles},
			{"decor-1", Level1Decors}
		};
	}

	public List<GameObject> GetList(string type, int level){
		List<GameObject> res;
		dico.TryGetValue (type + "-" + level.ToString (), out res);
		return res;
	}
}
