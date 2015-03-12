using UnityEngine;
using System.Collections;

public class LongswordWeaponTalentScript : TalentScript
{
    // Use this for initialization
    void Start()
    {
        talentName = "Longsword";
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
        talentName = "Longsword Weapon";
        talentType = TalentTypes.WeaponTalent;
        roundRequired = 15;
    }
}