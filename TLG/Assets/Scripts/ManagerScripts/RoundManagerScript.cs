using UnityEngine;
using System.Collections;

public class RoundManagerScript : MonoBehaviour 
{
    private int roundNumber = 1;

	// Use this for initialization
	void Start () 
    {
	
	}
	
    //increments the roundnumber
    public void NextRound()
    {
        if(roundNumber < 30)
            roundNumber++;
    }

    //returns the round number
    public int GetRound()
    {
        return roundNumber;
    }
}
