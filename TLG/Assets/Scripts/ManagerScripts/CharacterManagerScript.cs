﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor;

public class CharacterManagerScript : MonoBehaviour 
{
    public GameObject character;                //reference to the main character

    private Stats overallStats = new Stats();                 //holds the combination of the character's base stats and the equipments stats.
    private GameObject meleeWeapon;
    private GameObject rangeWeapon;
    private GameObject offensiveAbility;
    private GameObject defensiveAbility;
    private Sprite obj;

	// Use this for initialization
	void Start ()
    {
        if(!GameObject.Find("MainCharacter(Clone)"))
        {
            character = (GameObject)Instantiate(character);
            character.transform.parent = gameObject.transform;
        }
	}
	
    public Stats GetCharacterStats()
    {
        CalculateOverallStats();

        return overallStats;
    }
    
    public void AddMeleeWeapon(GameObject weapon)
    {
        DestroyPrevious("MeleeWeapon");
        meleeWeapon = (GameObject)Instantiate(weapon);
        meleeWeapon.transform.parent = character.transform;
    }

    public void AddRangeWeapon(GameObject weapon)
    {
        DestroyPrevious("RangeWeapon");
        rangeWeapon = (GameObject)Instantiate(weapon);
        rangeWeapon.transform.parent = character.transform;
    }

    public void AddOffensiveAbility(GameObject ability)
    {
        DestroyPrevious("OffensiveAbility");
        offensiveAbility = (GameObject)Instantiate(ability);
        offensiveAbility.transform.parent = character.transform;

    }

    public void AddDefensiveAbility(GameObject ability)
    {
        DestroyPrevious("DefensiveAbility");
        defensiveAbility = (GameObject)Instantiate(ability);
        defensiveAbility.transform.parent = character.transform;

    }


    public void AddTalent(GameObject talent)
    {

    }

    public void UpdatePrefab()
    {
        //this only works in editor
        //okay to not use since the prefab will get changed through the game, but remain it's original afterwards
        //PrefabUtility.ReplacePrefab(gameObject, PrefabUtility.GetPrefabParent(gameObject), ReplacePrefabOptions.ConnectToPrefab);

    }

    private void DestroyPrevious(string equipmentTag)
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag(equipmentTag))
        {
            Destroy(obj);
        }
    }

    private void CalculateOverallStats()
    {
        overallStats = new Stats();

        if(character != null)
        {
            overallStats.Strength += character.GetComponent<CharacterScript>().GetBaseStats().Strength;
            overallStats.Speed += character.GetComponent<CharacterScript>().GetBaseStats().Speed;
            overallStats.Dexterity += character.GetComponent<CharacterScript>().GetBaseStats().Dexterity;
            overallStats.Stamina += character.GetComponent<CharacterScript>().GetBaseStats().Stamina;
            overallStats.Intellect += character.GetComponent<CharacterScript>().GetBaseStats().Intellect;
            overallStats.Recovery += character.GetComponent<CharacterScript>().GetBaseStats().Recovery;
            overallStats.Reflex += character.GetComponent<CharacterScript>().GetBaseStats().Reflex;
        }
        if(meleeWeapon != null)
        {
            ///overallStats.Strength += meleeWeapon.GetComponent<MeleeWeaponScript>().GetStats().Strength; 
            //
            //this is the correct syntax i want to use, however for some reason when getting the script component, it doesn't get the str stat.
            //
            overallStats.Strength += meleeWeapon.GetComponent<MeleeWeaponScript>().str;
            overallStats.Speed += meleeWeapon.GetComponent<MeleeWeaponScript>().spd;
            overallStats.Dexterity += meleeWeapon.GetComponent<MeleeWeaponScript>().dex;
            overallStats.Stamina += meleeWeapon.GetComponent<MeleeWeaponScript>().stm;
            overallStats.Intellect += meleeWeapon.GetComponent<MeleeWeaponScript>().intl;
            overallStats.Recovery += meleeWeapon.GetComponent<MeleeWeaponScript>().rec;
            overallStats.Reflex += meleeWeapon.GetComponent<MeleeWeaponScript>().refl;
        }

        if(rangeWeapon != null)
        {
            overallStats.Strength += rangeWeapon.GetComponent<RangeWeaponScript>().str;
            overallStats.Speed += rangeWeapon.GetComponent<RangeWeaponScript>().spd;
            overallStats.Dexterity += rangeWeapon.GetComponent<RangeWeaponScript>().dex;
            overallStats.Stamina += rangeWeapon.GetComponent<RangeWeaponScript>().stm;
            overallStats.Intellect += rangeWeapon.GetComponent<RangeWeaponScript>().intl;
            overallStats.Recovery += rangeWeapon.GetComponent<RangeWeaponScript>().rec;
            overallStats.Reflex += rangeWeapon.GetComponent<RangeWeaponScript>().refl;
        }

        if(offensiveAbility != null)
        {
            overallStats.Strength += offensiveAbility.GetComponent<OffensiveAbilityScript>().str;
            overallStats.Speed += offensiveAbility.GetComponent<OffensiveAbilityScript>().spd;
            overallStats.Dexterity += offensiveAbility.GetComponent<OffensiveAbilityScript>().dex;
            overallStats.Stamina += offensiveAbility.GetComponent<OffensiveAbilityScript>().stm;
            overallStats.Intellect += offensiveAbility.GetComponent<OffensiveAbilityScript>().intl;
            overallStats.Recovery += offensiveAbility.GetComponent<OffensiveAbilityScript>().rec;
            overallStats.Reflex += offensiveAbility.GetComponent<OffensiveAbilityScript>().refl;
        }   

        if(defensiveAbility != null)
        {
            overallStats.Strength += defensiveAbility.GetComponent<DefensiveAbilityScript>().str;
            overallStats.Speed += defensiveAbility.GetComponent<DefensiveAbilityScript>().spd;
            overallStats.Dexterity += defensiveAbility.GetComponent<DefensiveAbilityScript>().dex;
            overallStats.Stamina += defensiveAbility.GetComponent<DefensiveAbilityScript>().stm;
            overallStats.Intellect += defensiveAbility.GetComponent<DefensiveAbilityScript>().intl;
            overallStats.Recovery += defensiveAbility.GetComponent<DefensiveAbilityScript>().rec;
            overallStats.Reflex += defensiveAbility.GetComponent<DefensiveAbilityScript>().refl;
        }
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

    public GameObject GetCharacter()
    {
        return GameObject.Find("MainCharacter(Clone)");
    }
}