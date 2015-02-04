using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    private Stats stats = new Stats();
    public float HP = 1;
    private SpriteRenderer healthBar;   //reference to the sprite health bar display
    private Vector3 healthScale;        //a local scale of the health bar.


	// Use this for initialization
	void Start () {
        //HP = stats.Stamina * 10;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
    }

    void Awake()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
        healthScale = healthBar.transform.localScale;

    }

    //reduce health base on damage
    public void TakeDamage(float dmg = 0)
    {
        HP--;// dmg;
        if(HP < 1)
        {
            Death();
        }

        UpdateHealthBar();
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void UpdateHealthBar()
    {
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - HP * 0.01f);
        healthBar.transform.localScale = new Vector3(healthScale.x * HP * 0.01f, 1, 1);
    }
}
