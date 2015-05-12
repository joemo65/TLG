using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class LeaderboardsUIManagerScript : MonoBehaviour 
{
	private string scoreLeaderboard = "CgkI4cnQsY8WEAIQAw";             //key to the score leaderboard.
	private string roundsSurvivedLeaderboard = "CgkI4cnQsY8WEAIQBA";    //key to the rounds survived leaderboard.
	private string enemiesVanquishedLeaderboard = "CgkI4cnQsY8WEAIQBQ"; //key to the enemies vanquished leaderboard.

	// Use this for initialization
	void Start () 
    {
	}

    public void OnXButtonClick()
    {
        Application.LoadLevel("MainMenuScene");
    }

    public void OnScoresButtonClick()
    {
        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(scoreLeaderboard);
    }

    public void OnEnemiesVanquishedButtonClick()
    {
        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(enemiesVanquishedLeaderboard);
    }

    public void OnRoundsSurvivedButtonClick()
    {
        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(roundsSurvivedLeaderboard);
    }
}
