using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {


	public GameObject[] Spawners;
	public float spawnRate=5.0f;
	public GameObject enemy;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("Spawn", 0f, spawnRate);
	}


	void Spawn()
	{
		int random = Random.Range (0, Spawners.Length);
		GameObject  enemyInstance = Instantiate (enemy, Spawners [random].transform.position, Spawners [random].transform.rotation) as GameObject;
	}


}
