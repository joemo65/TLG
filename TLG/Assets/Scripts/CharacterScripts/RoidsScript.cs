using UnityEngine;
using System.Collections;

public class RoidsScript : OffensiveAbilityScript
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public override void Activate()
    {
        transform.parent.GetComponent<CharacterScript>().str += 20;
        print(transform.parent.GetComponent<CharacterScript>().str);
    }
}
