using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class MainMenuUIManagerScript : MonoBehaviour 
{
    void Start()
    {
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if(success)
            {
                Debug.Log("success");
            }
        });
    }

	public void Play()
	{
		Application.LoadLevel ("CharacterMenuScene");
	}

	public void Leaderboards()
	{
		Application.LoadLevel ("LeaderboardsScene");
	}

    public void Quit()
    {
        ((PlayGamesPlatform) Social.Active).SignOut();
        Application.Quit();
    }
}
