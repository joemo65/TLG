using UnityEngine;
using System.Collections;


public class TalentScript : MonoBehaviour
{
    protected enum TalentTypes{StatTalent = 0, WeaponTalent, SpecialTalent};

    protected TalentTypes talentType = TalentTypes.StatTalent;
    protected int roundRequired = 0;
    protected string talentName = "";

    public virtual void Activate()
    {
        print(gameObject);
    }

    public virtual void SetTalentAttributesToDefault()
    {

    }

    public string GetTalentName()
    {
        return talentName;
    }

    public int GetRoundRequired()
    {
        return roundRequired;
    }
}
