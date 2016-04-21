using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;

public class WeaponCheck : MonoBehaviour {

    CancelButton cancelButton;

	UpgradeHandler upHandler;

	[SerializeField] private bool hasWeapon;

	[SerializeField] GameObject grabStats;

	//WeaponCheck checkHere;
	
	[SerializeField] Button sellWeapon;
	
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
        cancelButton = GameObject.FindGameObjectWithTag("Cancel").GetComponent<CancelButton>();
		upHandler = GameObject.FindGameObjectWithTag("UIHandler").GetComponent<UpgradeHandler>();
		hasWeapon = false;
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
		if (other.tag == "Turret" || other.tag == "Flame") 
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
            cancelButton.WeaponTrue();
			Instantiate(spawnerSpot, this.gameObject.transform.position, this.gameObject.transform.rotation);
			wasSelected = true;
		}
		
		if (hasWeapon == true) 
		{
			upgradeBar.Play("UpgradeBarUp");
            cancelButton.UpdateTrue();
            grabStats.GetComponent<StatManager>().CanUpgrade(true);
            grabStats.GetComponent<StatManager>().UpdateUI();
            Debug.Log(upHandler.WeaponsList().Count);
		}
	}


}
