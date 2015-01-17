﻿using UnityEngine;
using System.Collections;

public class BattleUIScript : MonoBehaviour {
    private bool paused = false;
    public Animator pausePanel;
    public Animator talentsPanel;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    #region PauseMenu
    //event handler for when the user selects the pause option
    public void OnPauseButtonClick()
    {
        //pause the game
        paused = true;
        //stop the game
        StartOrStopGame();
        //open the OptionsMenuUI
        OpenPauseMenu();
    }

    //when X button is clicked from the Options panel.
    public void OnOptionsXButtonClick()
    {
        //close the options panel
        ClosePauseMenu();
        //unpause the game
        paused = false;
        //continue the game
        StartOrStopGame();
    }

    private void ClosePauseMenu()
    {
        pausePanel.SetBool("isHidden", false);
        //issue causing menu to only show once.
        //pausePanel.enabled = false;
    }

    //opens the pause menu
    private void OpenPauseMenu()
    {
        pausePanel.enabled = true;
        pausePanel.SetBool("isHidden", true);
    }

    //pauses the game by starting or stopping game time dependant upon the bool paused.
    private void StartOrStopGame()
    {
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    //event handler for the talents button in the options menu.
    public void OnTalentsButtonClick()
    {
        talentsPanel.enabled = true;
        talentsPanel.SetBool("isHidden", true);
    }
#endregion
    #region TalentMenu
    //closes the talents menu
    public void OnTalentsXButtonClick()
    {
        talentsPanel.SetBool("isHidden", false);
    }
    #endregion
}