﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;

public class WeaponCheck : MonoBehaviour {
	
	UpgradeHandler upHandler;
	CancelButton myCancel;

	[SerializeField] private bool hasWeapon;
//	[SerializeField] bool wsUp;
//	[SerializeField] bool ugUp;

	[SerializeField] GameObject grabStats;

	//WeaponCheck checkHere;
	
	[SerializeField] Button sellWeapon;
	
	[SerializeField] GameObject cancelButton;
	
	[SerializeField] GameObject spawnerSpot;
	
	[SerializeField] GameObject weaponSelect;
	[SerializeField] GameObject upgradeSelect;
	[SerializeField] Animation weaponBar;
	[SerializeField] Animation upgradeBar;

	[SerializeField] bool wasSelected;

//	[SerializeField] Button updateSpeed;
//	[SerializeField] Button updateRange;

	// Use this for initialization
	void Awake () 
	{
		upHandler = GameObject.FindGameObjectWithTag("UIHandler").GetComponent<UpgradeHandler>();
		hasWeapon = false;
		cancelButton = GameObject.FindGameObjectWithTag ("Cancel");
		myCancel = cancelButton.GetComponent<CancelButton>();
		weaponSelect = GameObject.FindGameObjectWithTag ("WeaponSelect");
		upgradeSelect = GameObject.FindGameObjectWithTag ("UpgradeSelect");
		weaponBar = weaponSelect.GetComponent<Animation>();
		upgradeBar = upgradeSelect.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//HasWeapon ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Turret") 
		{
			grabStats = other.gameObject.transform.parent.gameObject;
			upHandler.WeaponsList ().Add (grabStats);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Turret" || other.tag == "Flame") 
		{
			hasWeapon = true;
		}
	}

	public bool HasWeapon()
	{
		return hasWeapon;
	}

	public void WeaponButton()
	{
		if (hasWeapon == false) 
		{
			weaponBar.Play("WeaponBarUp");
//			wsUp = true;
			Instantiate(spawnerSpot, this.gameObject.transform.position, this.gameObject.transform.rotation);
			cancelButton.SetActive(true);
			wasSelected = true;
		}

//		if (hasWeapon == false && wasSelected == true) 
//		{
//			myCancel.StopCover();
//			wasSelected = false;
//		}
		
		if (hasWeapon == true) 
		{
			upgradeBar.Play("UpgradeBarUp");
//			ugUp = true;
			grabStats.GetComponent<StatManager>().CanUpgrade(true);
			cancelButton.SetActive(true);
			Debug.Log(upHandler.WeaponsList().Count);
		}
	}

	public void ActivateCancel()
	{
		cancelButton.SetActive(true);
	}

}
