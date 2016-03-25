using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CancelButton : MonoBehaviour {

	BarDownCheck barDown;

	[SerializeField] GameObject cancelText;
	[SerializeField] GameObject downCheck;
	//[SerializeField] GameObject thisButton;
	[SerializeField] GameObject spawnSpot;

	[SerializeField] GameObject weaponSelect;
	[SerializeField] GameObject upgradeSelect;
	
	[SerializeField] Animation weaponBar;
	[SerializeField] Animation upgradeBar;

	void Awake()
	{
		barDown = GameObject.FindGameObjectWithTag("DownCheck").GetComponent<BarDownCheck>();
		weaponSelect = GameObject.FindGameObjectWithTag ("WeaponSelect");
		upgradeSelect = GameObject.FindGameObjectWithTag ("UpgradeSelect");
		weaponBar = weaponSelect.GetComponent<Animation>();
		upgradeBar = upgradeSelect.GetComponent<Animation>();
	}

	// Use this for initialization
	void Start () 
	{

	}

	void Update()
	{
		spawnSpot = GameObject.FindGameObjectWithTag ("SpawnHere");
	}

	public void StopCover()
	{
		if (barDown.WeaponDown () == false) 
		{
			weaponBar.Play("WeaponBarDown");
			Destroy(spawnSpot);
			this.gameObject.SetActive(false);
		}

		if (barDown.UpgradeDown () == false) 
		{
			upgradeBar.Play("UpgradeBarDown");
			this.gameObject.SetActive(false);
		}
	}
}
