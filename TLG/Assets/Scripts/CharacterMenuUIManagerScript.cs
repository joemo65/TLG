using UnityEngine;
using System.Collections;

public class CharacterMenuUIManagerScript : MonoBehaviour {
	
	public Animator abilityPanel;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//opens the select ability dialog.
	//need to expand to load based upon what ability grouping was selected.
	public void OpenAbilities()
	{
		abilityPanel.enabled = true;
		abilityPanel.SetBool ("isHidden", false);
	}
	
	public void CloseAbilities()
	{
		abilityPanel.SetBool ("isHidden", true);
	}
	
	void ShowAbilityPanel()
	{
		
	}
	
	public void StartBattle()
	{
		Application.LoadLevel ("BattleScene");
	}
}