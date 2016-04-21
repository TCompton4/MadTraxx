using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetAndHealth : MonoBehaviour {

	[SerializeField] Game_Manager myManager;
	[SerializeField] MainTurret curTurret;
	[SerializeField] GameObject thisCar;

	[SerializeField] float carHealth;
    //[SerializeField] float currentOil;
    [SerializeField]
    int oilMin;
    [SerializeField]
    int oilMax;
	[SerializeField] bool isDead;
	[SerializeField] bool inRange;

	[SerializeField] public List<GameObject> curTurrets = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		myManager = GameObject.FindObjectOfType<Game_Manager>().GetComponent<Game_Manager>();
		//currentOil = myManager.LevelOil ();
		thisCar = this.gameObject;
		carHealth = 50f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (carHealth <= 0) 
		{
			RemoveMe();
			myManager.PlusOil(Random.Range(oilMin, oilMax));
            myManager.MinusEnemy();
			isDead = true;
		}

		if (isDead == true) 
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (inRange == true) 
		{
			if (other.tag == "TurretShot") 
			{
				carHealth -= curTurret.HitDamage ();
				//Debug.Log ("Car Hit");
			}
		}

		if (other.tag == "TurretShot") 
		{
			Destroy(other.gameObject);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Holder") 
		{
			curTurrets.Add(other.gameObject);
			curTurret = other.gameObject.GetComponent<MainTurret>();
			inRange = true;
		}
	}


	public void RemoveMe()
	{
		foreach (GameObject turret in curTurrets) 
		{
			curTurret = turret.GetComponent<MainTurret>();
			curTurret.EnemyList ().Remove (thisCar);
		}
	}

	public bool IsDead()
	{
		return isDead;
	}
	
}
