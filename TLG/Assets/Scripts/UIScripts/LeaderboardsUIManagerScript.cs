using UnityEngine;
using System.Collections;

public class LeaderboardsUIManagerScript : MonoBehaviour 
{
    private GameObject playerManager = GameObject.Find("PlayerManager");    //reference the playermanager to find how many items to put inside the listbox

	// Use this for initialization
	void Start () 
    {
        CreateListBox();
	}


    public void OnXButtonClick()
    {
        Application.LoadLevel("MainMenuScene");
    }

    private void CreateListBox()
    {
        ArrayList list = playerManager.GetComponent<PlayerManagerScript>().GetList();
        for (int i = 0; i < list.Count; i++)
        {
            CreateButton(list[i]);
        }
    }

    private void CreateButton(object item)
    {
        //Instantiate(GUI)
    }
}
