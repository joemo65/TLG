using UnityEngine;
using System.Collections;

public class CharacterMeleeScript : MonoBehaviour 
{
    private Animator meleeAnimation;

	// Use this for initialization
	void Start ()
    {
	}

    void Awake()
    {
        meleeAnimation = transform.gameObject.GetComponent<Animator>();
        //meleeAnimation.
        if(meleeAnimation != null)
            meleeAnimation.SetTrigger("Melee"); //when the game starts, ready the melee weapon.
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
