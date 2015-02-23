using UnityEngine;
using System.Collections;

public class EnemyManagerScript : MonoBehaviour 
{
    public float spawnTime = 5f;		// The amount of time between each spawn.
    public float spawnDelay = 3f;		// The amount of time before spawning starts.
    public GameObject enemy1;		    //reference to the type of enemy to spawn
    public GameObject enemy2;           //reference to the type of enemy to spawn
    public GameObject enemy3;           //reference to the type of enemy to spawn
    public GameObject enemy4;           //reference to the type of enemy to spawn

    private bool newRound = true;
    private int totalEnemies = 0;
    private int enemiesToSpawn = 0;
    private int numberOfFighters = 0;
    private int numberOfSpearman = 0;
    private int numberOfLegionares = 0;
    private int numberOfLions = 0;
    private int currentRound = 0;
    private GameObject roundManager;    //reference to the round manager
    private GameObject leftSpawn;       //reference to the left spawn object
    private GameObject rightSpawn;      //reference to the right spawn object

	// Use this for initialization
	void Start () 
    {
        roundManager = GameObject.Find("RoundManager");     //set reference to the RoundManager Object.
        leftSpawn = GameObject.Find("LeftSpawn");           //set reference to the LeftSpawn Object.
        rightSpawn = GameObject.Find("RightSpawn");         //set reference to the RightSpawn Object.

        
        InvokeRepeating("SpawnEnemies", spawnTime, spawnDelay); // SpawnEnemies(); //start ng the spawn enemies function
	}

	private void SpawnEnemies()
    {
        if (newRound)
        {
            currentRound = roundManager.GetComponent<RoundManagerScript>().GetRound();

            CalculateEnemiesToSpawn();
        }

        if (totalEnemies > 0)
        {
            newRound = false;

            numberOfFighters = SpawnEnemy(enemy1,numberOfFighters);
            numberOfSpearman = SpawnEnemy(enemy2, numberOfSpearman);
            numberOfLegionares = SpawnEnemy(enemy3, numberOfLegionares);
            numberOfLions = SpawnEnemy(enemy4, numberOfLions);
        }
        else
        {
            newRound = true;
            roundManager.GetComponent<RoundManagerScript>().NextRound();
            spawnTime -= 1;
            spawnDelay -= 2;
        }

    }

    private void CalculateEnemiesToSpawn()
    {

        if(currentRound < 10)
        {
            //spawn fighters based on round number
            numberOfFighters = currentRound * 2;
        }
        else if(currentRound < 20)
        {
            //spawn 10 fighters + spearman based on round number
            numberOfFighters = 10;
            numberOfSpearman = (currentRound - 10) * 2;
        }
        else if(currentRound < 30)
        {
            //spawn 10 fighters + 10 spearman + legionares based on round number
            numberOfFighters = 10;
            numberOfSpearman = 10;
            numberOfLegionares = (currentRound - 20) * 2;
        }
        else if(currentRound == 30)
        {
            //spawn 10 fighters + 10 spearman + 10 legionares + lion boss
            numberOfFighters = 10;
            numberOfSpearman = 10;
            numberOfLegionares = 10;
            numberOfLions = 1;
        }
        else
        {
            //endless mode
        }

        //add all the enemies to the total number
        totalEnemies += numberOfFighters;
        totalEnemies += numberOfSpearman;
        totalEnemies += numberOfLegionares;
        totalEnemies += numberOfLions;

    }

    private void CheckNumberOfEnemies()
    {
        int count = 0;
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if(obj.name == "EnemyFighter(Clone)")
            {
                count++;
            }   
        }
        totalEnemies = count;
    }

    private int SpawnEnemy(GameObject enemy,int number)
    {   
        if(number > 0)
        {
            if(number % 2 == 1)
            {
                rightSpawn.GetComponent<SpawnerScript>().Spawn(enemy);
            }
            else
            {
                leftSpawn.GetComponent<SpawnerScript>().Spawn(enemy);
            }
            number--;
            totalEnemies--;
        }
 
        return number;
    }
}