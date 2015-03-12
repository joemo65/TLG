using UnityEngine;
using System.Collections;

public class StrengthStatTalentScript : TalentScript
{

	// Use this for initialization
	void Start ()
    {
        SetTalentAttributesToDefault();
	}

    public override void Activate()
    {
        print("Activate: + 20 strength");
        GameObject.Find("CharacterManager").GetComponent<CharacterManagerScript>().AddStat(new Stats(20));
    }

    public override void SetTalentAttributesToDefault()
    {
        talentName = "Strength";
        talentType = TalentTypes.StatTalent;
        roundRequired = 5;
    }
}
