using UnityEngine;
using System.Collections;

public class IntellectStatTalentScript : TalentScript
{
    // Use this for initialization
    void Start()
    {
        SetTalentAttributesToDefault();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Activate()
    {
        print("Activate: + 20 intellect");
        GameObject.Find("CharacterManager").GetComponent<CharacterManagerScript>().AddStat(new Stats(0,0,0,0,20));
    }

    public override void SetTalentAttributesToDefault()
    {
        talentName = "Intellect";
        talentType = TalentTypes.StatTalent;
        roundRequired = 5;
    }
}
