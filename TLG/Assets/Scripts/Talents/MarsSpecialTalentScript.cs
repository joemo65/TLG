using UnityEngine;
using System.Collections;

public class MarsSpecialTalentScript : TalentScript
{
	// Use this for initialization
	void Start () 
    {
        talentName = "Mars";
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
        talentName = "Mars";
        talentType = TalentTypes.SpecialTalent;
        roundRequired = 20;
    }
}