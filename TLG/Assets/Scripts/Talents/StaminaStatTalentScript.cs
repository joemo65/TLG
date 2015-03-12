using UnityEngine;
using System.Collections;

public class StaminaStatTalentScript : TalentScript
{
    
    // Use this for initialization
    void Start()
    {
        SetTalentAttributesToDefault();
    }

    public override void Activate()
    {
        print("Activate: + 20 stamina");
        GameObject.Find("CharacterManager").GetComponent<CharacterManagerScript>().AddStat(new Stats(0,0,0,20));
    }

    public override void SetTalentAttributesToDefault()
    {
        talentName = "Stamina";
        talentType = TalentTypes.StatTalent;
        roundRequired = 5;
    }
}