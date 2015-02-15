using UnityEngine;
using System.Collections;

public class MainMenuUIManagerScript : MonoBehaviour {
	public void Play()
	{
		Application.LoadLevel ("CharacterMenuScene");
	}

	public void Leaderboards()
	{
		Application.LoadLevel ("LeaderboardsScene");
	}
}
