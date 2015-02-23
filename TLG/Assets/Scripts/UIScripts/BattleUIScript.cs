using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleUIScript : MonoBehaviour 
{
   
    private GameObject GameManager;
    private GameObject optionsPanel;
    private GameObject talentsPanel;
    private bool paused = false;
    private ScoreManagerScript scoreReference;      //reference to the score manager script.
    private Text scoreNumber;                       //reference to the score UI text.
    private Text roundNumber;                       //reference to the round UI text.
    private GameObject characterManager;            //reference to the game manager.
    private GameObject roundManager;                //reference to the round manager.

	// Use this for initialization
	void Start () 
    {
        scoreReference = GameObject.Find("ScoreManager").GetComponent<ScoreManagerScript>();    //set the reference to the scoreManager's script.

        foreach (Text txt in gameObject.GetComponentsInChildren<Text>())
        {
            if (txt.name == "ScoreNumber")
            {
                scoreNumber = txt;   //set the reference to the Score Number text.
            }

            if(txt.name == "RoundNumber")
            {
                roundNumber = txt;    //set the reference to the round number text.
            }
        }

        optionsPanel = GameObject.Find("OptionsMenuCanvas");
        talentsPanel = GameObject.Find("TalentsMenuCanvas");
        characterManager = GameObject.Find("CharacterManager");
        roundManager = GameObject.Find("RoundManager");

        //set the image of the button to the image of the special
        GameObject.Find("PrimarySpecialAbilityButton").GetComponentInChildren<RawImage>().texture = 
            GameObject.FindGameObjectWithTag("OffensiveAbility").GetComponent<SpriteRenderer>().sprite.texture;

        //set the image of the button to the image of the special
        GameObject.Find("SecondarySpecialAbilityButton").GetComponentInChildren<RawImage>().texture =
            GameObject.FindGameObjectWithTag("DefensiveAbility").GetComponent<SpriteRenderer>().sprite.texture;

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (scoreNumber != null)
        {
            //update the score number
            scoreNumber.text = scoreReference.TotalScore.ToString();      //update this so that it has a reference to the object instead of the script like RoundManager
        }

        if(roundNumber != null)
        {
            //update the round number
            roundNumber.text = roundManager.GetComponent<RoundManagerScript>().GetRound().ToString();
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

    #region Restart
    public void OnRestartClick()
    {
        Application.LoadLevel("BattleScene");
    }
#endregion

    #region Quit
    public void OnQuitClick()
    {
        Application.LoadLevel("MainMenuScene");
    }
#endregion

    #region SpecialAbilityOne
    public void OnSpecialAbilityOneClick()
    {
        //characterManager.GetComponent<CharacterManagerScript>().GetCharacter();
        GameObject specialRef = GameObject.FindGameObjectWithTag("OffensiveAbility");

        if(specialRef != null)
        {
            specialRef.GetComponent<OffensiveAbilityScript>().Activate();
        }
    }
    #endregion

    #region SpecialAbilityTwo
    public void OnSpecialAbilityTwoClick()
    {
        //characterManager.GetComponent<CharacterManagerScript>().GetCharacter();
        GameObject specialRef = GameObject.FindGameObjectWithTag("DefensiveAbility");

        if (specialRef != null)
        {
            specialRef.GetComponent<DefensiveAbilityScript>().Activate();
        }
    }
    #endregion
}