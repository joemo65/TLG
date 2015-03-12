using UnityEngine;
using System.Collections;

public class RecoveryStatTalentScript : TalentScript
{

	// Use this for initialization
	void Start () 
    {
        talentName = "Recovery";
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
        talentName = "Recovery";
        talentType = TalentTypes.StatTalent;
        roundRequired = 10;
    }
}
