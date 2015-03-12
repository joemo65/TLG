using UnityEngine;
using System.Collections;

public class DexterityStatTalentScript : TalentScript
{
    // Use this for initialization
    void Start()
    {
        talentName = "Dexterity";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Activate()
    {
         base.Activate();
    }

    public override void SetTalentAttributesToDefault()
    {
        talentName = "Dexterity";
        talentType = TalentTypes.StatTalent;
        roundRequired = 10;
    }
}