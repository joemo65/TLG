using UnityEngine;
using System.Collections;

public class ReflexStatTalentScript : TalentScript
{
	// Use this for initialization
	void Start () 
    {
        talentName = "Reflex";
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
        talentName = "Reflex";
        talentType = TalentTypes.StatTalent;
        roundRequired = 10;
    }
}
