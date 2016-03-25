using UnityEngine;
using System.Collections;

public class BarDownCheck : MonoBehaviour {

	[SerializeField] bool weaponDown;
	[SerializeField] bool upgradeDown;

	[SerializeField] GameObject cancelButton;

	void Awake()
	{
		cancelButton = GameObject.FindGameObjectWithTag ("Cancel");
	}

	// Use this for initialization
	void Start () 
	{
		cancelButton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (weaponDown == true && upgradeDown == true) {
			cancelButton.SetActive (false);
		} 
		else 
		{
			cancelButton.SetActive (true);
		}

	}


	//If either Select bar collider is down
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "WeaponSelect") 
		{
			weaponDown = true;
		}
		if (other.tag == "UpgradeSelect") 
		{
			upgradeDown = true;
		}
	}

	//If either Select bar collider is up
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "WeaponSelect") 
		{
			weaponDown = false;
		}
		if (other.tag == "UpgradeSelect") 
		{
			upgradeDown = false;
		}
	}


	//Returns bool value
	public bool WeaponDown()
	{
		return weaponDown;
	}

	public bool UpgradeDown()
	{
		return upgradeDown;
	}
}
