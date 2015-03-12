using UnityEngine;
using System.Collections;

public class BrothersSpecialTalentScript : TalentScript
{

	// Use this for initialization
	void Start () 
    {
        talentName = "Brothers";
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
        talentName = "Brothers";
        talentType = TalentTypes.SpecialTalent;
        roundRequired = 20;
    }
}
