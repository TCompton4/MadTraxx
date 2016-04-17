using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CancelButton : MonoBehaviour {

	[SerializeField] GameObject spawnSpot;

	[SerializeField] GameObject weaponSelect;
	[SerializeField] GameObject upgradeSelect;
	
	[SerializeField] Animation weaponBar;
	[SerializeField] Animation upgradeBar;

    [SerializeField]
    private bool weaponUp;

    [SerializeField]
    private bool updateUp;

	void Awake()
	{
		weaponSelect = GameObject.FindGameObjectWithTag ("WeaponSelect");
		upgradeSelect = GameObject.FindGameObjectWithTag ("UpgradeSelect");
		weaponBar = weaponSelect.GetComponent<Animation>();
		upgradeBar = upgradeSelect.GetComponent<Animation>();
	}

	// Use this for initialization
	void Start () 
	{
        weaponUp = false;
        updateUp = false;
	}

	void Update()
	{
		spawnSpot = GameObject.FindGameObjectWithTag ("SpawnHere");

        if ((weaponUp == false) && (updateUp == false))
        {
            this.gameObject.SetActive(false);
        }
	}

	public void StopCover()
	{
        if (weaponUp == true)
        {
            weaponBar.Play("WeaponBarDown");
            Destroy(spawnSpot);
            this.gameObject.SetActive(false);
            weaponUp = false;
        }

        if (updateUp == true)
        {
            upgradeBar.Play("UpgradeBarDown");
            this.gameObject.SetActive(false);
            updateUp = false;
        }
	}

    public void WeaponTrue()
    {
        weaponUp = true;
        this.gameObject.SetActive(true);
    }

    public void UpdateTrue()
    {
        updateUp = true;
        this.gameObject.SetActive(true);
    }

    public void WeaponFalse()
    {
        weaponUp = false;
    }

    public void UpdateFalse()
    {
        updateUp = false;
    }
}
