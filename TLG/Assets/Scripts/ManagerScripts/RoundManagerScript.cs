using UnityEngine;
using System.Collections;

public class RoundManagerScript : MonoBehaviour 
{
    private Achievements achievements;      //contains the achievements to be unlocked

    //changing the round number to round six for testing talents.
    private int roundNumber = 5;//1;

    //increments the roundnumber
    public void NextRound()
    {
        if (roundNumber < 30)
        {
            //check to see if the round should provide a talent
            if (CheckTalentRound())
            { 
                
                //add a talent point to the character manager
                GameObject.Find("CharacterManager").GetComponent<CharacterManagerScript>().AddTalentPoint(1);
            }
            
            //CheckAchievementRound();
            
            GameObject.Find("ScoreManager").GetComponent<ScoreManagerScript>().SurvivedRound(roundNumber);

            roundNumber++;  //move the round to the next number
        }
    }

    //returns the round number
    public int GetRound()
    {
        return roundNumber;
    }

    public bool CheckTalentRound()
    {
        bool returnValue = false;

        //if the roundNumber is under 25 so only 4 talents are allowed per play through
        if (roundNumber < 25)
        {
            //every 5th round is a talent round.
            if (roundNumber % 5 == 0)
            {
                returnValue = true;
            }
        }

        return returnValue;
    }

    private void CheckAchievementRound()
    {
        if(roundNumber == 1)
        {
            Social.ReportProgress(achievements.GetAchievementList()[0].ToString(),100.0f, (bool success) =>
            {
                Debug.Log("Achievement unlocked!");
            });
        }
        else if(roundNumber == 5)
        {
            Social.ReportProgress(achievements.GetAchievementList()[1].ToString(), 100.0f, (bool success) =>
            {
                Debug.Log("Achievement unlocked!");
            });
        }
        else if(roundNumber == 10)
        {
            Social.ReportProgress(achievements.GetAchievementList()[2].ToString(), 100.0f, (bool success) =>
            {
                Debug.Log("Achievement unlocked!");
            });
        }
        else if(roundNumber == 20)
        {
            Social.ReportProgress(achievements.GetAchievementList()[3].ToString(), 100.0f, (bool success) =>
            {
                Debug.Log("Achievement unlocked!");
            });
        }
        else if(roundNumber == 30)
        {
            Social.ReportProgress(achievements.GetAchievementList()[4].ToString(), 100.0f, (bool success) =>
            {
                Debug.Log("Achievement unlocked!");
            });
        }
    }
}
