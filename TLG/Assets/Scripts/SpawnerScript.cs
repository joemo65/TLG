using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemies.

	// Use this for initialization
	void Start () {
		//calls the spawn function after the 
		InvokeRepeating ("Spawn", spawnDelay, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn()
	{
		int numberOfEnemies = 10;

		//create enemy 1
		//Instantiate (enemies [numberOfEnemies], Transform.position, Transform.rotation);

	}
}
