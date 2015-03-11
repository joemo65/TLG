using UnityEngine;
using System.Collections;

public class OffensiveAbilityScript : MonoBehaviour
{
    //to set each individual weapon to be different
    public float str = 0;
    public float spd = 0;
    public float dex = 0;
    public float stm = 0;
    public float intl = 0;
    public float rec = 0;
    public float refl = 0;

    private Stats stats = new Stats();
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public Stats GetStats()
    {
        return stats;
    }

    public virtual void Activate()
    {
    }
}
