using UnityEngine;
using System.Collections;

public class MeleeWeaponScript : MonoBehaviour
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
        stats = new Stats(str, spd, dex, stm, intl, rec, refl);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyScript>().TakeDamage(1);
        }
    }

    public Stats GetStats()
    {
        return stats;
    }
}
