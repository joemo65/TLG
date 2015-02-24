using UnityEngine;
using System.Collections;

public class PlayerManagerScript : MonoBehaviour 
{
    //may change the data structure.
    private ArrayList listOfPlayers = new ArrayList();

	// Use this for initialization
	void Start () 
    {
        //TEST: add 3 items to the list
        listOfPlayers.Add(1);
        listOfPlayers.Add(2);
        listOfPlayers.Add(3);

	    //TODO: load in user stats.
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public int GetCount()
    {
        return listOfPlayers.Count;
    }

    public ArrayList GetList()
    {
        return listOfPlayers;
    }

    private void Sort()
    {
        //sort the data based on rank

    }
}
