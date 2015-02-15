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
        meleeAnimation.SetTrigger("Melee"); //when the game starts, ready the melee weapon.
    }

	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
           meleeAnimation.SetTrigger("Melee");
           meleeAnimation.SetTrigger("Melee");
        }
    }   
}
