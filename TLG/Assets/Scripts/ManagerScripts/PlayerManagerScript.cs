using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class PlayerManagerScript : MonoBehaviour 
{
    //may change the data structure.
    private ArrayList listOfPlays = new ArrayList();
    //private int port = 25001;
    //private string address = "96.41.175.241";

	// Use this for initialization
	void Start () 
    {
        ConnectToServer();
	}

	public void ConnectToServer()
    {
        //print("Connect to server");
        //Network.Connect(address);
    }

	// Update is called once per frame
	void Update () 
    {
	
	}

    public int GetCount()
    {
        return listOfPlays.Count;
    }

    public ArrayList GetList()
    {
        return listOfPlays;
    }

    private void Sort()
    {
        //sort the data based on rank

    }
}
