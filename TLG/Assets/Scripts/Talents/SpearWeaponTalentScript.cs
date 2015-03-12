using UnityEngine;
using System.Collections;

public class SpearWeaponTalentScript : TalentScript
{
    // Use this for initialization
    void Start()
    {
        talentName = "Spear Weapon";
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
        talentName = "Spear Weapon";
        talentType = TalentTypes.WeaponTalent;
        roundRequired = 15;
    }
}