using UnityEngine;
using System.Collections;

public class RangeWeaponScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        // Destroy the weapon after 2 seconds if it doesn't get destroyed before then.
        Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            DestroyObject(gameObject);
        }
    }
}
