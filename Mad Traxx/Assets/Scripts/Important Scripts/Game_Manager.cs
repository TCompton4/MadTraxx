using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Game_Manager : MonoBehaviour {

	//CreateWeapon weaponScript;
	
	[SerializeField] float levelOil;
	[SerializeField] float newOil;
	[SerializeField] Text oilText;
	
	// Use this for initialization
	void Start () 
	{
		//weaponScript = GameObject.FindGameObjectWithTag ("UIHandler").GetComponent<CreateWeapon>();
		levelOil = 3000f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		oilText.text = "Oil: " + levelOil;
		
		if (newOil <= 0) 
		{
			newOil = 0;
		}
	}
	
	public float LevelOil()
	{
		return levelOil;
	}
	
	public void MinusOil(float minusCost)
	{
		levelOil -= minusCost;
	}
	
	public void PlusOil(float plusCost)
	{
		levelOil += plusCost;
	}

//	public void OilAmount(float myOil)
//	{
//
//	}
}
