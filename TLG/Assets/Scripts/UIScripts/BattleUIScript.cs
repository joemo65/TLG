﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GooglePlayGames;

public class BattleUIScript : MonoBehaviour 
{
    public GameObject button;

    private GameObject optionsPanel;
    private GameObject talentsPanel;
    private GameObject gameOverPanel;

    private bool paused = false;                    //used to pause the game

    private Text scoreNumber;                       //reference to the score UI text.
    private Text roundNumber;                       //reference to the round UI text.
    private Text talentPointNumber;                 //reference to the talent point UI text.
    private Text alertText;                         //reference to the alert UI text.
    private Text currentHealthNumber;               //reference to the current health UI Text.
    private Text overallHealthNumber;               //reference to the overall health UI Text.

    private GameObject scoreManager;                //reference to the score manager.
    private GameObject characterManager;            //reference to the game manager.
    private GameObject roundManager;                //reference to the round manager.
    private GameObject gameManager;                 //reference to the game manager.

	private string scoreLeaderboard = "CgkI4cnQsY8WEAIQAw";             //key to the score leaderboard.
	private string roundsSurvivedLeaderboard = "CgkI4cnQsY8WEAIQBQ";    //key to the rounds survived leaderboard.
	private string enemiesVanquishedLeaderboard = "CgkI4cnQsY8WEAIQBA"; //key to the enemies vanquished leaderboard.

	// Use this for initialization
	void Start () 
    {
        ///
        ///note: make sure to add this script to the text game object so that the text registers as a child gameobject.
        ///
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

            if (txt.name == "CurrentHealthNumber")
            {
                currentHealthNumber = txt;    //set the reference to the current health text.
            }

            if(txt.name == "OverallHealthNumber")
            {
                overallHealthNumber = txt;    //set the reference to the overall health text.
            }

            if(txt.name == "AlertText")
            {
                alertText = txt;     //set the reference to the talent point alert.
            }
        }

        optionsPanel = GameObject.Find("OptionsMenuCanvas");
        talentsPanel = GameObject.Find("TalentsMenuCanvas");
        gameOverPanel = GameObject.Find("GameOverCanvas");

        gameManager = GameObject.Find("GameManager");
        characterManager = GameObject.Find("CharacterManager");
        roundManager = GameObject.Find("RoundManager");
        scoreManager = GameObject.Find("ScoreManager");

        foreach (Text txt in talentsPanel.GetComponentsInChildren<Text>())
        {
            if(txt.name == "TalentPointNumber")
            {
                talentPointNumber = txt;
            }
        }

        //set the image of the button to the image of the special
        GameObject.Find("PrimarySpecialAbilityButton").GetComponentInChildren<RawImage>().texture = 
            GameObject.FindGameObjectWithTag("OffensiveAbility").GetComponent<SpriteRenderer>().sprite.texture;

        //set the image of the button to the image of the special
        GameObject.Find("SecondarySpecialAbilityButton").GetComponentInChildren<RawImage>().texture =
            GameObject.FindGameObjectWithTag("DefensiveAbility").GetComponent<SpriteRenderer>().sprite.texture;

        DisplayTalents();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (scoreNumber != null)
        {
            //update the score number
            scoreNumber.text = scoreManager.GetComponent<ScoreManagerScript>().TotalScore.ToString();     
        }

        if(roundNumber != null)
        {
            //update the round number
            roundNumber.text = roundManager.GetComponent<RoundManagerScript>().GetRound().ToString();
        }

        if(talentPointNumber != null)
        {
            talentPointNumber.text = characterManager.GetComponent<CharacterManagerScript>().GetTalentPoints().ToString();
        }

        if(overallHealthNumber != null )
        {
            overallHealthNumber.text = characterManager.GetComponent<CharacterManagerScript>().GetOverallHealth().ToString();
        }

        if (currentHealthNumber != null)
        {
            currentHealthNumber.text = characterManager.GetComponent<CharacterManagerScript>().GetCurrentHealth().ToString();
            if (characterManager.GetComponent<CharacterManagerScript>().GetCurrentHealth() < 1)
            {
                GameOver();
            }
        }

        if(alertText != null)
        {
            if(characterManager.GetComponent<CharacterManagerScript>().GetTalentPoints() > 0)
            {
                StartCoroutine(Alert());
            }
        }
	}

    private IEnumerator Alert()
    {
        ShowAlert("+1 Talent Point!");  //show the text
        yield return new WaitForSeconds(3); //show it for 3 seconds
        HideAlert();    //remove the alert from the screen
    }
    
    private void ShowAlert(string alert)
    {
        alertText.text = alert; //update the alert to show the text from the parameter
        alertText.transform.position = new Vector3(Screen.width/2, alertText.transform.position.y, 0);     //move the alert to the middle of the camera
    }

    private void HideAlert()
    {
        alertText.transform.position = new Vector3(-900, alertText.transform.position.y, 0);//move the alert off the camera
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
    //on start, adds talents into panel.
    public void DisplayTalents()
    {
        GameObject talentsCanvas = GameObject.Find("TalentsCanvas");    //the area within the talentsPanel
        ArrayList talents = gameManager.GetComponent<GameManagerScript>().GetTalentsList();

        GameObject talentButton = button;

        if (talentButton != null)
        {
            if (talents.Count > 0)
            {
                for (int i = 0; i < talents.Count; i++)
                {
                    GameObject currentTalent = (GameObject)talents[i];                  //get the talent    
                    currentTalent.GetComponent<TalentScript>().SetTalentAttributesToDefault();  //set the talents to their names, basically a constructor method.
                    GameObject buttonClone = (GameObject)Instantiate(talentButton);     //create a button to put the talent in
                    Text buttonText = buttonClone.GetComponentInChildren<Text>();       //set reference to the button's text          
                    buttonText.text = currentTalent.GetComponent<TalentScript>().GetTalentName();   //update the button's text to the talent's name
                    buttonClone.GetComponent<Button>().onClick.AddListener(() =>
                       GameObject.Find("BattleUIManager").GetComponent<BattleUIScript>().OnTalentButtonClick(currentTalent));   //add the event handler for the click
                    buttonClone.transform.SetParent(talentsCanvas.transform, false);    //put the button in the talent canvas.
                    ConfigureTalentsToTreeForm(buttonClone, i);                         //create a talent tree appearance.

                    //need to add an event for the buttons
                }
            }
        }
    }

    public void OnTalentButtonClick(GameObject talent)
    {
        if(ValidTalentPick(talent))
        {
            characterManager.GetComponent<CharacterManagerScript>().AddTalent(talent);
            characterManager.GetComponent<CharacterManagerScript>().RemoveTalentPoint();
        }
    }

    private bool ValidTalentPick(GameObject talent)
    {
        bool returnValue = false;
        
        if(characterManager.GetComponent<CharacterManagerScript>().GetTalentPoints() > 0)
        {
            if(roundManager.GetComponent<RoundManagerScript>().GetRound() > talent.GetComponent<TalentScript>().GetRoundRequired())
            {
                returnValue = true;
            }
        }


        return returnValue;
    }

    //used to set the buttons in the right place, creates a 3x4 grid      
    private void ConfigureTalentsToTreeForm(GameObject button, int i)
    {
        ///  
        ///columns
        ///
        //if the first column
        if (i % 3 == 0)
        {
            //keep original position
            //change color to red
            button.GetComponent<Image>().color = Color.red;
        }
        //if the second column
        else if (i % 3 == 1)
        {
            //move button over in the x direction
            button.transform.localPosition = new Vector3(button.transform.localPosition.x + 150, button.transform.localPosition.y, 0);
            //change color to green
            button.GetComponent<Image>().color = Color.green;
        }
        //if the third column
        else if (i % 3 == 2)
        {
            //move button over in the x direction
            button.transform.localPosition = new Vector3(button.transform.localPosition.x + 300, button.transform.localPosition.y, 0);
            //change color to cyan
            button.GetComponent<Image>().color = Color.cyan;
        }

        ///
        ///rows
        ///
        if (i / 3 == 0)
        {
            //keep original y position
        }
        //if the second row
        else if (i / 3 == 1)
        {
            //move button over in the y direction
            button.transform.localPosition = new Vector3(button.transform.localPosition.x, button.transform.localPosition.y - 100, 0);
        }
        //if the third row
        else if (i / 3 == 2)
        {
            //move button over in the y direction
            button.transform.localPosition = new Vector3(button.transform.localPosition.x, button.transform.localPosition.y - 200, 0);
        }
        //if the fourth row
        else if (i / 3 == 3)
        {
            //move button over in the y direction
            button.transform.localPosition = new Vector3(button.transform.localPosition.x, button.transform.localPosition.y - 300, 0);
        }
    }

    //event handler for the talents button in the options menu.
    public void OnTalentsButtonClick()
    {
		GameObject canvas = GameObject.Find ("BattleCanvas");
		canvas.GetComponent<RectTransform>().anchoredPosition = new Vector3 (900, 0, 10);
        talentsPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 10);

        //talentsPanel.enabled = true;
        //talentsPanel.SetBool("isHidden", true);
    }

   
    //closes the talents menu
    public void OnTalentsXButtonClick()
    {
		GameObject.Find ("BattleCanvas").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (0, 0, 10);
        talentsPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(900, 0, 10);
        //talentsPanel.SetBool("isHidden", false);
    }
    #endregion

    #region Restart
    public void OnRestartClick()
    {
        //broken currently
        //Application.LoadLevel("BattleScene");
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

    #region GameOver
    private void GameOver()
    {
        Text goScoreNumber;
        Text goRoundsSurvivedNumber;
        Text goEnemiesVanquishedNumber;

        Time.timeScale = 0;     //stop the game

        //set the reference for the texts on the panel
        foreach (Text txt in gameOverPanel.GetComponentsInChildren<Text>())
        {
            if(txt.name == "GOScoreNumber")
            {
                goScoreNumber = txt;                //set the reference for the score on the panel
                goScoreNumber.text = scoreManager.GetComponent<ScoreManagerScript>().TotalScore.ToString();     //update the score on the panel
            }
            if (txt.name == "GORoundsSurvivedNumber")
            {
                goRoundsSurvivedNumber = txt;       //set the reference for the number of enemies vanquished on the panel
                goRoundsSurvivedNumber.text = scoreManager.GetComponent<ScoreManagerScript>().RoundsSurvived.ToString();
            }
            if(txt.name == "GOEnemiesVanquishedNumber")
            {
                goEnemiesVanquishedNumber = txt;    //set the reference for the number of rounds survived on the panel
                goEnemiesVanquishedNumber.text = scoreManager.GetComponent<ScoreManagerScript>().EnemiesVanquished.ToString();
            }
        }
        gameOverPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 10);   //show the panel
    }

    public void OnGameOverOkayClick()
    {
        //report score to score leaderboard.
        Social.ReportScore((long)scoreManager.GetComponent<ScoreManagerScript>().TotalScore, scoreLeaderboard, (bool success) =>
        {
            Debug.Log("leaderboard post successful");
        });

        //report score to enemies vanquished leaderboard.
        Social.ReportScore((long)scoreManager.GetComponent<ScoreManagerScript>().EnemiesVanquished, enemiesVanquishedLeaderboard, (bool success) =>
        {
            Debug.Log("leaderboard post successful");
        });

        //report score to the rounds survived leaderboard.
        Social.ReportScore((long)scoreManager.GetComponent<ScoreManagerScript>().RoundsSurvived, roundsSurvivedLeaderboard, (bool success) =>
        {
            Debug.Log("leaderboard post successful");
        });

        //return the to main menu
        Application.LoadLevel("MainmenuScene");
    }
    #endregion
}