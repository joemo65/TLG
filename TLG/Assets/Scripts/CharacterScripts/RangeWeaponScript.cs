using UnityEngine;
using System.Collections;

public class RangeWeaponScript : MonoBehaviour 
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

        //if the spear isn't a child object of the main character object
        if(gameObject.transform.parent == null)
        {
            // Destroy the weapon after 2 seconds if it doesn't get destroyed before then.
            Destroy(gameObject, 2);
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyScript>().TakeDamage(5);
        }
    }

    public Stats GetStats()
    {
        return stats;
    }
}
