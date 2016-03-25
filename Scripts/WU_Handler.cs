using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;

public class WU_Handler : MonoBehaviour {

	WeaponCheck checkHere;

	[SerializeField] GameObject tapArea;
	[SerializeField] GameObject cancelButton;
	
	[SerializeField] GameObject spawnerSpot;
	
	[SerializeField] GameObject weaponSelect;
	[SerializeField] GameObject upgradeSelect;
	
	[SerializeField] Animation weaponBar;
	[SerializeField] Animation upgradeBar;
	
	// Use this for initialization
	void Start () 
	{
		checkHere = tapArea.GetComponentInParent<WeaponCheck> ();
		
		weaponSelect = GameObject.FindGameObjectWithTag ("WeaponSelect");
		upgradeSelect = GameObject.FindGameObjectWithTag ("UpgradeSelect");
		weaponBar = weaponSelect.GetComponent<Animation>();
		upgradeBar = upgradeSelect.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void WeaponButton()
	{
		if (checkHere.HasWeapon () == false) 
		{
			weaponBar.Play("WeaponBarUp");
			Instantiate(spawnerSpot, gameObject.transform.parent.transform.position, gameObject.transform.parent.transform.rotation);
			cancelButton.SetActive(true);
		}
		
		if (checkHere.HasWeapon () == true) 
		{
			upgradeBar.Play("UpgradeBarUp");
			cancelButton.SetActive(true);
		}
	}
}
