using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpgradeHandler : MonoBehaviour {

    CancelButton cancelButton;

	[SerializeField] GameObject upgradeSelect;
	[SerializeField] Animation upgradeBar;

	[SerializeField] GameObject myUpdater;

	//holds all active weapons
	[SerializeField] public List<GameObject> activeWeapons = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
        cancelButton = GameObject.FindGameObjectWithTag("Cancel").GetComponent<CancelButton>();
        upgradeSelect = GameObject.FindGameObjectWithTag ("UpgradeSelect");
		upgradeBar = upgradeSelect.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	#region UpgradeSelect button calls
	public void UpgradeSpeed ()
	{
		foreach (GameObject weapon in activeWeapons) 
		{
			weapon.GetComponent<StatManager>().UpdateSpeed();
			DoneUpdating();
		}
	}

	public void UpgradeRange ()
	{
		foreach (GameObject weapon in activeWeapons) 
		{
			weapon.GetComponent<StatManager>().UpdateRange();
			DoneUpdating();
		}
    }

	public void UpgradeDamage ()
	{
		foreach (GameObject weapon in activeWeapons) 
		{
			weapon.GetComponent<StatManager>().UpdateDamage();
			DoneUpdating();
		}
    }

	public void UpgradeFireRate ()
	{
		foreach (GameObject weapon in activeWeapons) 
		{
			weapon.GetComponent<StatManager>().UpdateFireRate();
			DoneUpdating();
		}
    }
	#endregion

	public void DoneUpdating()
	{
		upgradeBar.Play("UpgradeBarDown");
        cancelButton.UpdateFalse();
    }

	public List<GameObject> WeaponsList()
	{
		return activeWeapons;
	}
}
