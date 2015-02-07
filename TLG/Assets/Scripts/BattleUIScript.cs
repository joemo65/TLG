using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleUIScript : MonoBehaviour {
   
    //public Animator pausePanel;
    //public Animator talentsPanel;

    private GameObject optionsPanel;
    private GameObject talentsPanel;
    private bool paused = false;
    private ScoreManagerScript scoreReference;      //reference to the score manager script.
    private Text textReference;                     //reference to the score UI text.

	// Use this for initialization
	void Start () 
    {
        scoreReference = GameObject.Find("ScoreManager").GetComponent<ScoreManagerScript>();    //set the reference to the scoreManager's script.
        textReference = GetComponent<Text>();   //set the reference to the Score Number text.
        optionsPanel = GameObject.Find("OptionsMenuCanvas");
        talentsPanel = GameObject.Find("TalentsMenuCanvas");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (textReference != null)
        {
            //update the score number
            textReference.text = scoreReference.TotalScore.ToString();
        }
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
        //pausePanel.SetBool("isHidden", false);
        //issue causing menu to only show once.
        //pausePanel.enabled = false;
        optionsPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(-900, 0, 10);
    }

    //opens the pause menu
    private void OpenPauseMenu()
    {
        optionsPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 10);
        //pausePanel.enabled = true;
        //pausePanel.SetBool("isHidden", true);
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
#endregion

#region TalentMenu
    //event handler for the talents button in the options menu.
    public void OnTalentsButtonClick()
    {
        talentsPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 10);
        //talentsPanel.enabled = true;
        //talentsPanel.SetBool("isHidden", true);
    }

   
    //closes the talents menu
    public void OnTalentsXButtonClick()
    {
        talentsPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(900, 0, 10);
        //talentsPanel.SetBool("isHidden", false);
    }
    #endregion
}