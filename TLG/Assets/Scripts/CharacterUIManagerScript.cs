using UnityEngine;
using System.Collections;

public class CharacterUIManagerScript : MonoBehaviour
{
    //public Animator abilityPanel; //removing animation for now.
    private GameObject panel;       //reference to the panel that contains the list of gameobjects.
    private GameObject character;   //reference to the character that will be used.

    // Use this for initialization
    void Start()
    {
        character = GameObject.Find("MainCharacter");
        panel = GameObject.Find("AbilityPanel");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenMeleeWeapons()
    {
        panel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 10);
        //tell the panel what list to use
        //panel.ListType("Melee");
    }

    public void OpenRangeWeapons()
    {
        panel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 10);
        //panel.ListType("Range");
    }

    public void OpenSpecials()
    {
        panel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 10);
        //panel.ListType("Specials");
    }

    public void ClosePanel()
    {
        panel.GetComponent<RectTransform>().anchoredPosition = new Vector3(800, 0, 10);
        //update the reference to the character.
    }

    public void StartBattle()
    {
        //update the prefab of the main character that will be used in the battle scene.
        Application.LoadLevel("BattleScene");
    }
}