using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterUIManagerScript : MonoBehaviour
{
    //public Animator abilityPanel; //removing animation for now.
    private GameObject equipmentPanel;      //reference to the panel that contains the list of gameobjects.
    private Text equipmentType;             //reference to the equipment type
    private RawImage currentEquipmentImage; //reference to update the current equipment picture
    private Text currentEquipmentText;      //reference to the current equipment's name
    private ArrayList equipmentList;        //contains the list of equipment that is passed.
    private int currentElement;             //to keep track of the current element.
    // Use this for initialization
    void Start()
    {
        equipmentPanel = GameObject.Find("EquipmentPanel");     //set reference to the equipment panel

        //go through all the Texts on the panel
        foreach (Text txt in equipmentPanel.GetComponentsInChildren<Text>())
        {
            //if the text is the title of the panel
            if(txt.name == "EquipmentTypeText")
            {
                equipmentType = txt;    //set the reference to title 
            }
            else if(txt.name == "CurrentEquipmentText")
            {
                currentEquipmentText = txt; //set the reference for the current equipment's text.
            }
        }  
        //go through all the images on the panel
        foreach (RawImage img in equipmentPanel.GetComponentsInChildren<RawImage>())
        {
            //if the image on the panel is the current image
            if(img.name == "CurrentEquipmentImage")
            {
                currentEquipmentImage = img;    //set the reference to where the current image should be.
            }
        }
    }
    #region Open
    public void OpenMeleeWeapons()
    {
        equipmentList = GameObject.Find("GameManager").GetComponent<GameManagerScript>().GetMeleeList();    //get the list of the melee weapons
        SetCurrentImage();  //set the current image to the first element in the array
        SetCurrentText();   //set the current text to the first element in the array 
        equipmentPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 10);  //move to the middle of the screen
        equipmentType.text = "Melee";   //update the text to melee

    }

    public void OpenRangeWeapons()
    {
        equipmentList = GameObject.Find("GameManager").GetComponent<GameManagerScript>().GetRangeList();    //get the list of the range weapons
        SetCurrentImage();  //set the current image to the first element in the array
        SetCurrentText();   //set the current text to the first element in the array 
        equipmentPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 10);  //move to the middle of the screen
        equipmentType.text = "Range";   //update the text to range
    }

    public void OpenOffensiveSpecials()
    {
        equipmentList = GameObject.Find("GameManager").GetComponent<GameManagerScript>().GetOffensiveAbilityList();    //get the list of the offensive specials
        SetCurrentImage();   //set the current image to the first element in the array
        SetCurrentText();   //set the current text to the first element in the array 
        equipmentPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 10);  //move to the middle of the screen
        equipmentType.text = "Offensive";   //update the text to Specials
    }
    
    public void OpenDefensiveSpecials()
    {
        equipmentList = GameObject.Find("GameManager").GetComponent<GameManagerScript>().GetDefensiveAbilityList();    //get the list of the offensive specials
        SetCurrentImage();   //set the current image to the first element in the array
        SetCurrentText();   //set the current text to the first element in the array 
        equipmentPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 10);  //move to the middle of the screen
        equipmentType.text = "Defensive";   //update the text to Specials
    }
    #endregion
    #region Next
    public void Right()
    {
        //if the list isn't empty
        if(equipmentList != null)
        {
            //if the current element is less that the number of equipments
            if(currentElement+1 < equipmentList.Count)
            {
                currentElement += 1;    //move to the next item in the list
            }
            else
            {
                currentElement = 0;     //start at the beginning
            }
            SetCurrentImage(currentElement);    //set the next item's image
            SetCurrentText(currentElement);     //set the next item's text
        }
    }
    public void Left()
    {
        //if the list isn't empty
        if (equipmentList != null)
        {
            //if the current element is less that the number of equipments
            if (currentElement - 1 > -1)
            {
                currentElement -= 1;    //move to the previous item in the list
            }
            else
            {
                currentElement = equipmentList.Count-1;     //go to the last element
            }
            SetCurrentImage(currentElement);    //set the next item's image
            SetCurrentText(currentElement);     //set the next item's text
        }
    }
    #endregion

    #region Close
    public void ClosePanel()
    {
        //update to the character.
        //
        currentElement = 0; //reset current
        equipmentPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(800, 0, 10);    //move the panel off the screen.
    }
    #endregion
    private void SetCurrentImage(int currentElement = 0)
    {
        //if the list isn't empty
        if (equipmentList != null)
        {
            //create a local reference to the element of the list
            GameObject current = (GameObject)equipmentList[currentElement];

            //set the image to current's image
            currentEquipmentImage.texture = current.GetComponent<SpriteRenderer>().sprite.texture;
        }
        else
        {
            //if the list is empty, set the texture back to nothing
            currentEquipmentImage.texture = null;
        }
    }

    private void SetCurrentText(int currentElement = 0)
    {
        //if the list isn't empty
        if (equipmentList != null)
        {
            //create a local reference to the current element in the list
            GameObject current = (GameObject)equipmentList[currentElement];

            //update the text to be the same as the element's name
            currentEquipmentText.text = current.name;
        }
        else
        {
            //if the list is empty, reset the text to nothing
            currentEquipmentImage.texture = null;
        }
    }

    public void StartBattle()
    {
        //update the prefab of the main character that will be used in the battle scene.
        Application.LoadLevel("BattleScene");
    }
}