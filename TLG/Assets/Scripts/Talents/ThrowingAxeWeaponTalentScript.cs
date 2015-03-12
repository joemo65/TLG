using UnityEngine;
using System.Collections;

public class ThrowingAxeWeaponTalentScript : TalentScript
{

	// Use this for initialization
	void Start () 
    {
        talentName = "Throwing Axe";
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public override void Activate()
    {
        base.Activate();
    }

    public override void SetTalentAttributesToDefault()
    {
        talentName = "Throwing Axe Weapon";
        talentType = TalentTypes.WeaponTalent;
        roundRequired = 15;
    }
}
