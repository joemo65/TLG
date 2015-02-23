using UnityEngine;
using System.Collections;

//object that contains the lists of equipment.
//equipment includes weapons, specials, and talents
public class GameManagerScript : MonoBehaviour {

    public GameObject CharacterManager;

    //for now, include the specials from unity as a public member.
    //would like to add a way to search for them based on tag.
    public GameObject meleeWeapon0;
    public GameObject meleeWeapon1;
    public GameObject meleeWeapon2;
    public GameObject meleeWeapon3;

    public GameObject rangeWeapon0;
    public GameObject rangeWeapon1;
    public GameObject rangeWeapon2;
    public GameObject rangeWeapon3;

    public GameObject offensiveAbility0;
    public GameObject offensiveAbility1;
    public GameObject offensiveAbility2;
    public GameObject offensiveAbility3;

    public GameObject defensiveAbility0;
    public GameObject defensiveAbility1;
    public GameObject defensiveAbility2;
    public GameObject defensiveAbility3;

    public GameObject talent0;
    public GameObject talent1;
    public GameObject talent2;
    public GameObject talent3;
    public GameObject talent4;
    public GameObject talent5;
    public GameObject talent6;
    public GameObject talent7;
    public GameObject talent8;

    private ArrayList meleeWeaponList = new ArrayList();
    private ArrayList rangeWeaponList = new ArrayList();
    private ArrayList offensiveSpecialsList = new ArrayList();
    private ArrayList defensiveSpecialsList = new ArrayList();
    private ArrayList talentsList = new ArrayList();

    void Start()
    {
        //very messy, need to clean up, probably remove these functions
        CreateMeleeWeaponList();
        CreateRangeWeaponList();
        CreateOffensiveAbilityList();
        CreateDefensiveAbilityList();
        CreateTalentList();

        //print("melee: " + meleeWeaponList.Count);
        //print("range: " + rangeWeaponList.Count);
        //print("Ospecials: " + offensiveSpecialsList.Count);
        //print("Dspecials: " + defensiveSpecialsList.Count);
        //print("Talents: " + talentsList.Count);
    }

    #region CreateLists
    private void CreateMeleeWeaponList()
    {
        if(meleeWeapon0 != null)
            meleeWeaponList.Add(meleeWeapon0);
        if (meleeWeapon1 != null)
            meleeWeaponList.Add(meleeWeapon1);
        if (meleeWeapon2 != null)
            meleeWeaponList.Add(meleeWeapon2);
        if (meleeWeapon3 != null)
            meleeWeaponList.Add(meleeWeapon3);
    }

    private void CreateRangeWeaponList()
    {
        if(rangeWeapon0 != null)
            rangeWeaponList.Add(rangeWeapon0);
        if (rangeWeapon1 != null)
            rangeWeaponList.Add(rangeWeapon1);
        if (rangeWeapon2 != null)
            rangeWeaponList.Add(rangeWeapon2);
        if (rangeWeapon3 != null)
            rangeWeaponList.Add(rangeWeapon3);
    }

    private void CreateOffensiveAbilityList()
    {
        if(offensiveAbility0 != null)
            offensiveSpecialsList.Add(offensiveAbility0);
        if (offensiveAbility1 != null)
            offensiveSpecialsList.Add(offensiveAbility1);
        if (offensiveAbility2 != null)
            offensiveSpecialsList.Add(offensiveAbility2);
        if (offensiveAbility3 != null)
            offensiveSpecialsList.Add(offensiveAbility3);
    }

    private void CreateDefensiveAbilityList()
    {
        if(defensiveAbility0 != null)
            defensiveSpecialsList.Add(defensiveAbility0);
        if (defensiveAbility1 != null)
            defensiveSpecialsList.Add(defensiveAbility1);
        if (defensiveAbility2 != null)
            defensiveSpecialsList.Add(defensiveAbility2);
        if (defensiveAbility3 != null)
            defensiveSpecialsList.Add(defensiveAbility3);
    }

    private void CreateTalentList()
    {
        if(talent0 != null)
            talentsList.Add(talent0);
        if (talent1 != null)
            talentsList.Add(talent1);
        if (talent2 != null)
            talentsList.Add(talent2);
        if (talent3 != null)
            talentsList.Add(talent3);
        if (talent4 != null)
            talentsList.Add(talent4);
        if (talent5 != null)
            talentsList.Add(talent5);
        if (talent6 != null)
            talentsList.Add(talent6);
        if (talent7 != null)
            talentsList.Add(talent7);
        if (talent8 != null)
            talentsList.Add(talent8);
    }
    #endregion
    #region GetLists
    public ArrayList GetMeleeList()
    { 
        return meleeWeaponList; 
    }
    public ArrayList GetRangeList()
    {
        return rangeWeaponList;
    }
    public ArrayList GetOffensiveAbilityList()
    {
        return offensiveSpecialsList;
    }
    public ArrayList GetDefensiveAbilityList()
    {
        return defensiveSpecialsList;
    }
    public ArrayList GetTalentsList()
    {
        return talentsList;
    }
    #endregion
}
