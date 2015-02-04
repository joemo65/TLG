using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject enemy;		    //enemy to spawn

	// Use this for initialization
	void Start () {
		//calls the spawn function after the 
		InvokeRepeating ("Spawn", spawnDelay, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //currently endless spawning.
    //will need to update this later to confirm with rounds
    //and different enemies.
	private void Spawn()
	{
        // Instantiate a random enemy.
        //int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemy, transform.position, transform.rotation);
	}
}
