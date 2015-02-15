using UnityEngine;
using System.Collections;

//contains the objects that make up a character
public class CharacterScript : MonoBehaviour {

    private Stats stats = new Stats();
    private GameObject meleeWeapon;
    private GameObject rangeWeapon;
    private GameObject offensiveAbility;
    private GameObject defensiveAbility;

	// Use this for initialization
	void Start ()
    {
	    meleeWeapon = new GameObject();
        rangeWeapon = new GameObject();
        offensiveAbility = new GameObject();
        defensiveAbility = new GameObject();
	}

    public Stats GetStats()
    {
        return stats;
    }

    public GameObject MeleeWeapon
    {
        get { return meleeWeapon; }
        set { meleeWeapon = value; }
    }

    public GameObject RangeWeapon
    {
        get { return rangeWeapon; }
        set { rangeWeapon = value; }
    }
    public GameObject OffensiveAbility
    {
        get { return offensiveAbility; }
        set { offensiveAbility = value; }
    }
    public GameObject DefensiveAbility
    {
        get { return defensiveAbility; }
        set { defensiveAbility = value; }
    }
}
