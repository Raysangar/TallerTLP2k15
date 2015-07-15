using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {


	public GameObject[] Spawners;
	public float spawnRate=5.0f;
	public GameObject enemy;

	// Use this for initialization
	void Start () {

		Invoke("Spawn",spawnRate);
		InvokeRepeating ("IncreaseDifficulty", 5f,15f);
	}


	void Spawn()
	{
		int random = Random.Range (0, Spawners.Length);
		GameObject  enemyInstance = Instantiate (enemy, Spawners [random].transform.position, Spawners [random].transform.rotation) as GameObject;
		Invoke("Spawn",spawnRate);
	}

	void IncreaseDifficulty()
	{
		if (spawnRate > 0.5f) {

			spawnRate*=0.5f;
			Debug.Log (spawnRate);
		}
	}

}
