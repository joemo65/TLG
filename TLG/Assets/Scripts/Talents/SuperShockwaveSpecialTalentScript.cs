using UnityEngine;
using System.Collections;

public class SuperShockwaveSpecialTalentScript : TalentScript
{

	// Use this for initialization
	void Start () 
    {
        talentName = "Super Shockwave";
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
        talentName = "Super Shockwave";
        talentType = TalentTypes.SpecialTalent;
        roundRequired = 20;
    }
}
