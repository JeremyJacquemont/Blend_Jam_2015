using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourcesLib : MonoBehaviour {

	public List<GameObject> Level1LightObstacles;

	public List<GameObject> Level1HeavyObstacles;

	public List<GameObject> Level1FixedObstacles;

	public List<GameObject>  Level1EndObstacles ;

	public List<GameObject> Level1EffectObstacles;

	public List<GameObject> Level1Decors;

	public List<GameObject> Level2LightObstacles;
	
	public List<GameObject> Level2HeavyObstacles;
	
	public List<GameObject> Level2FixedObstacles;

	public List<GameObject>  Level2EndObstacles ;
	
	public List<GameObject> Level2EffectObstacles;
	
	public List<GameObject> Level2Decors;

	public List<GameObject> Level3LightObstacles;
	
	public List<GameObject> Level3HeavyObstacles;
	
	public List<GameObject> Level3FixedObstacles;

	public List<GameObject> Level3EndObstacles;
	
	public List<GameObject> Level3EffectObstacles;
	
	public List<GameObject> Level3Decors;

	public List<GameObject> Bonus;

	private Dictionary<string, List<GameObject>> dico;

	void Awake(){
		dico = new Dictionary<string, List<GameObject>> ()
		{
			{"light-1", Level1LightObstacles},
			{"heavy-1", Level1HeavyObstacles},
			{"fixed-1", Level1FixedObstacles},
			{"end-1", Level1EndObstacles},
			{"effect-1", Level1EffectObstacles},
			{"decor-1", Level1Decors},

			{"light-2", Level2LightObstacles},
			{"heavy-2", Level2HeavyObstacles},
			{"fixed-2", Level2FixedObstacles},
			{"end-2", Level2EndObstacles},
			{"effect-2", Level2EffectObstacles},
			{"decor-2", Level2Decors},

			{"light-3", Level3LightObstacles},
			{"heavy-3", Level3HeavyObstacles},
			{"fixed-3", Level3FixedObstacles},
			{"end-3", Level3EndObstacles},
			{"effect-3", Level3EffectObstacles},
			{"decor-3", Level3Decors},

			{"bonus-0", Bonus}
		};
	}

	public List<GameObject> GetList(string type, int level){
		List<GameObject> res;
		dico.TryGetValue (type + "-" + level.ToString (), out res);
		return res;
	}
}
