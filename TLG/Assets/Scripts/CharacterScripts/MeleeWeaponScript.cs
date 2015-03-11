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
    private GameObject characterManager;
    private static float damage = 0;

	// Use this for initialization
	void Start () 
    {
        stats = new Stats(str, spd, dex, stm, intl, rec, refl);
        if (gameObject.GetComponentInParent<CharacterScript>() != null)
        {
            characterManager = GameObject.Find("CharacterManager");
        }
        else if(gameObject.GetComponentInParent<EnemyScript>() != null)
        {
            characterManager = transform.parent.gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (characterManager != null)
        {
            if(characterManager.GetComponent<CharacterManagerScript>() != null)
            {
                //quick fix, need to find a way to remove this 'if' for debuffs to become a possibilty.
                if (characterManager.GetComponent<CharacterManagerScript>().GetOverallStats().Strength != 0)
                {
                    damage = characterManager.GetComponent<CharacterManagerScript>().GetOverallStats().Strength * 0.5f;
                }
            }
            else
            {
                damage = characterManager.GetComponent<EnemyScript>().strength;
            }

        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            if (gameObject.GetComponentInParent<CharacterScript>() != null)
            {
                col.gameObject.GetComponent<EnemyScript>().TakeDamage(damage);
            }
        }

        if (col.tag == "Player")
        {
            //print("weapon->player collision");
            col.gameObject.GetComponent<CharacterScript>().SetTakingDamage(true);
            col.gameObject.GetComponent<CharacterScript>().TakeDamage(damage);
        }
    }

    public Stats GetStats()
    {
        return stats;
    }
}
