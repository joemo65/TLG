using UnityEngine;
using System.Collections;

//container class for the achievemnent keys
public class Achievements : MonoBehaviour
{
    private ArrayList achievementsList = new ArrayList();

    private string enterTheArena = "CgkIu5vLvc8SEAIQAQ";
    private string sacredGround = "CgkIu5vLvc8SEAIQAg";
    private string theBringingOfRain = "CgkIu5vLvc8SEAIQBQ";
    private string theyAreEntertained = " CgkIu5vLvc8SEAIQAw";
    private string championOfTheArena = " CgkIu5vLvc8SEAIQBA";

	// Use this for initialization
	void Start () 
    {
        achievementsList.Add(enterTheArena);
        achievementsList.Add(sacredGround);
        achievementsList.Add(theBringingOfRain);
        achievementsList.Add(theyAreEntertained);
        achievementsList.Add(championOfTheArena);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public ArrayList GetAchievementList()
    {
        return achievementsList;
    }
}
