using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class LeaderboardsUIManagerScript : MonoBehaviour 
{
    private string scoreLeaderboard = "CgkIu5vLvc8SEAIQBg";             //key to the score leaderboard.
    private string roundsSurvivedLeaderboard = "CgkIu5vLvc8SEAIQBw";    //key to the rounds survived leaderboard.
    private string enemiesVanquishedLeaderboard = "CgkIu5vLvc8SEAIQCA"; //key to the enemies vanquished leaderboard.

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
