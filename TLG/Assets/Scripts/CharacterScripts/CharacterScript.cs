using UnityEngine;
using System.Collections;

//contains the objects that make up a character
public class CharacterScript : MonoBehaviour
{
    //to set each individual weapon to be different
    public float str = 0;
    public float spd = 0;
    public float dex = 0;
    public float stm = 0;
    public float intl = 0;
    public float rec = 0;
    public float refl = 0;

    private Stats baseStats = new Stats(1, 1, 1, 1, 1, 1, 1);            //the stats of the character
    private static float health = 10;                                    //the base health of the character
    private bool takingDamage = false;
    private float damageTaken = 0;

    // Use this for initialization
    void Start()
    {
    }

    public Stats GetBaseStats()
    {
        return baseStats;
    }

    public float GetHealth()
    {
        return health;
    }
    
    public void TakeDamage(float dmg = 0)
    {
        damageTaken = dmg;
    }

    //the enemy says that taking damage has occured, which is being polled by the character manager
    public void SetTakingDamage(bool hit)
    {
        takingDamage = hit;
    }

    public bool IsTakingDamage()
    {
        return takingDamage;
    }

    //used to get the amount of damage for the characterManager.
    public float GetDamageTaken()
    {
        return damageTaken;
    }
}
