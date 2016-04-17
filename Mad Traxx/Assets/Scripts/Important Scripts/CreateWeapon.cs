using UnityEngine;
using System.Collections;

public class CreateWeapon : MonoBehaviour {

	Game_Manager myManager;
    CancelButton cancelButton;

	[SerializeField] GameObject thisSpot;
	[SerializeField] GameObject myTurret;
	[SerializeField] GameObject myFlame;
	[SerializeField] GameObject myCannon;
	[SerializeField] GameObject mySpikes;

	[SerializeField] float currentOil;

	[SerializeField] GameObject weaponSelect;
	[SerializeField] Animation weaponBar;
	
	//[SerializeField] private bool noTurret;
	
	// Use this for initialization
	void Start () 
	{
        cancelButton = GameObject.FindGameObjectWithTag("Cancel").GetComponent<CancelButton>();
        myManager = GameObject.FindObjectOfType<Game_Manager>().GetComponent<Game_Manager>();
		currentOil = myManager.LevelOil ();
		//noTurret = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		weaponSelect = GameObject.FindGameObjectWithTag ("WeaponSelect");
		weaponBar = weaponSelect.GetComponent<Animation>();
		CurrentOil ();
	}

	#region Button calls to create weapons
	public void MakeTurret()
	{
		thisSpot = GameObject.FindGameObjectWithTag ("SpawnHere");
		Instantiate (myTurret, thisSpot.transform.position, transform.rotation);
		myManager.MinusOil (50);
		weaponBar.Play("WeaponBarDown");
        cancelButton.WeaponFalse();
		Destroy (thisSpot);
	}

	public void MakeFlame()
	{
		thisSpot = GameObject.FindGameObjectWithTag ("SpawnHere");
		Instantiate (myFlame, thisSpot.transform.position, transform.rotation);
		myManager.MinusOil (150);
		weaponBar.Play("WeaponBarDown");
        cancelButton.WeaponFalse();
        Destroy (thisSpot);
	}

	public void MakeCannon()
	{
		thisSpot = GameObject.FindGameObjectWithTag ("SpawnHere");
		Instantiate (myCannon, thisSpot.transform.position, transform.rotation);
		myManager.MinusOil (300);
		weaponBar.Play("WeaponBarDown");
        cancelButton.WeaponFalse();
        Destroy (thisSpot);
	}

	public void MakeSpikes()
	{
		thisSpot = GameObject.FindGameObjectWithTag ("SpawnHere");
		Instantiate (mySpikes, thisSpot.transform.position, transform.rotation);
		myManager.MinusOil (500);
		weaponBar.Play("WeaponBarDown");
        cancelButton.WeaponFalse();
        Destroy (thisSpot);
	}

	#endregion

	//called to communicate with Game_Manger to adjust oil amount
	void SubtractOil(float cost)
	{
		currentOil -= cost;
	}

	public float CurrentOil()
	{
		return currentOil;
	}
}
