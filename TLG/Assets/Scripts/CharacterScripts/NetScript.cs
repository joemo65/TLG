using UnityEngine;
using System.Collections;

public class NetScript : DefensiveAbilityScript
{

	// Use this for initialization
	void Start () 
    {
        //if the net object doesn't have a parent
        if (transform.parent == null)
            Destroy(gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public override void Activate()
    {
        //get a reference to see if the character is facing right
        if(transform.parent.GetComponent<MoveCharacterScript>().facingRight)
            Instantiate(gameObject, new Vector3(transform.parent.localPosition.x + 5, transform.parent.localPosition.y + 14, 0), Quaternion.Euler(0, 0, 0));    //create a copy of itself
        else
            Instantiate(gameObject, new Vector3(transform.parent.localPosition.x - 5, transform.parent.localPosition.y + 14, 0), Quaternion.Euler(0, 0, 0));    //create a copy of itself
    } 
}
