using UnityEngine;
using System.Collections;

public class CharacterManagerScript : MonoBehaviour {

    public GameObject character;    //reference to the main character

    private CharacterScript characterScript;    //reference to the main character's script, which contains it's information.

	// Use this for initialization
	void Start ()
    {
        characterScript = character.GetComponent<CharacterScript>();    //set reference to the character's script
	}
	
    public Stats GetCharacterStats()
    {
        return characterScript.GetStats();
    }

    public void SetMeleeWeapon(GameObject weapon)
    {
        characterScript.MeleeWeapon = weapon;
    }

    public void SetRangeWeapon(GameObject weapon)
    {
        characterScript.RangeWeapon = weapon;
    }

    public void SetOffensiveAbility(GameObject ability)
    {
        characterScript.OffensiveAbility = ability;
    }

    public void SetDefensiveAbility(GameObject ability)
    {
        characterScript.DefensiveAbility = ability;
    }

    public void AddTalent(GameObject talent)
    {

    }
}
