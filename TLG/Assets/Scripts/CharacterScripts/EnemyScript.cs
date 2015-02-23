using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour{

    public float HP = 1;
    public float moveSpeed = 8f;
    public float score = 100;                   //how much points this enemy unit is worth.

    private GameObject playerReference;
    private Stats stats;
    private SpriteRenderer healthBar;           //reference to the sprite health bar display
    private Vector3 healthScale;                //a local scale of the health bar.
    private ScoreManagerScript scoreReference;  //reference to the score Manager
    private float startPosition;                //get the start position for movement logic

	void Start () 
    {
        playerReference = GameObject.FindGameObjectWithTag("Player");
        scoreReference = GameObject.Find("ScoreManager").GetComponent<ScoreManagerScript>();
        //HP = stats.Stamina * 10;
	}

    void Awake()
    {
        startPosition = transform.position.x;
    }

	// Update is called once per frame
	void Update () 
    {
	}

    void OnCollsionEnter2D(Collider2D col)
    {
        // If any of the colliders is an Obstacle...
        if (col.tag == "Obstacle")
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        //update the health of the enemy unit
        if (HP < 1)
        {
            Death();    
        }

        //move towards the player   
        if(startPosition < 0 )
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            //rigidbody2D.velocity = new Vector2(-transform.localScale.x * moveSpeed, rigidbody2D.velocity.y);	
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            //rigidbody2D.velocity = new Vector2(transform.localScale.x * moveSpeed, rigidbody2D.velocity.y);
        }
    }

    private void Flip()
    {
        // Multiply the x component of localScale by -1.
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }

    //reduce health base on damage
    public void TakeDamage(float dmg = 0)
    {
        HP -= dmg;

        if(HP < 1)
        {
            Death();
        }

        UpdateHealthBar();
    }

    public void Death()
    {
        scoreReference.CalculateTotalScore(score);  //give the score manager the score of the enemy
        Destroy(gameObject);    //destroy the object
    }

    public void UpdateHealthBar()
    {
        //healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - HP * 0.01f);
        //healthBar.transform.localScale = new Vector3(healthScale.x * HP * 0.01f, 1, 1);
    }
}
