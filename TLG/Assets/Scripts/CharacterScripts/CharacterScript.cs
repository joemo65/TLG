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

    private Stats baseStats = new Stats(1, 1, 1, 1, 1, 1, 1);     //the stats of the character

    // Use this for initialization
    void Start()
    {
    }

    public Stats GetBaseStats()
    {
        return baseStats;
    }
}
