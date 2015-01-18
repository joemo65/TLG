using UnityEngine;
using System.Collections;

public class CharacterMeleeScript : MonoBehaviour {

    private float damage;
    private float coolDown;
    private float swingTime;
    private Animator meleeAnimation;

	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        meleeAnimation = transform.root.gameObject.GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update () {
        //if they press the melee button
        if (Input.GetButtonDown("Fire1"))
        {
            meleeAnimation.SetTrigger("Melee");
        }
	}


}
