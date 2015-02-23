using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour 
{
  	// Use this for initialization
	void Start ()
    {
		
	}

	public void Spawn(GameObject enemy)
	{
        Instantiate(enemy, transform.position, transform.rotation);
	}
}
