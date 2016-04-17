using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainTurret : MonoBehaviour {
	
	TargetAndHealth tAndHealth;

	[SerializeField] GameObject theGun;
	[SerializeField] GameObject theBarrel;
	[SerializeField] GameObject turretShot;
	
	[SerializeField] float myRadius;
	[SerializeField] float damp;
	[SerializeField] float moveSpeed;
	[SerializeField] float maxMove;
	[SerializeField] float fireRate;
	[SerializeField] float hitDamage;

	[SerializeField] Transform thisGun;
	[SerializeField] Transform barrelPos;
	[SerializeField] Transform theEnemy;
	[SerializeField] GameObject curEnemy;
	
	[SerializeField] public List<GameObject> myTargets = new List<GameObject>();
	
	[SerializeField] Quaternion enemyRot;
	[SerializeField] private bool enemyEntered;
	[SerializeField] int numEnemies;

	// Use this for initialization
	void Start () 
	{
		thisGun = this.gameObject.transform.GetChild (1).gameObject.transform;
		theBarrel = this.gameObject.transform.GetChild (2).gameObject;
		maxMove = 4f;
		moveSpeed = 3f;
		fireRate = 0.5f;
		hitDamage = 6f;
		myRadius = 4f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		thisGun = theGun.transform;
		barrelPos = theBarrel.transform;
		numEnemies = myTargets.Count;

		#region Call Accessors

		MoveSpeed();
		FireRate();
		TargetRange();
		HitDamage();

		#endregion

		#region Updating Accessors

		this.gameObject.GetComponent<CapsuleCollider>().radius = TargetRange();

		#endregion

//		transform.rotation = enemyRot;

		if (numEnemies > 0) 
		{
			enemyEntered = true;
		}
		
		if (numEnemies == 0) 
		{
			enemyEntered = false;
			damp = 1;
		}
		
		if (enemyEntered == true) 
		{
//			foreach (GameObject car in myTargets) {
//				tAndHealth = car.GetComponent<TargetAndHealth>();
//			}

//		    tAndHealth.IsDead ();
			fireRate -= Time.deltaTime;
			curEnemy = myTargets [0];
			theEnemy = curEnemy.transform;

			damp += Time.deltaTime * moveSpeed;
			if(damp >= maxMove)
			{
				damp = maxMove;
			}

			Quaternion rotation = Quaternion.LookRotation(theEnemy.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damp);
			if(fireRate <= 0)
			{
				Instantiate(turretShot, barrelPos.position, barrelPos.rotation);
				fireRate = 0.3f;
			}
//			transform.LookAt (theEnemy);
			FollowEnemy();
		}

//		if (tAndHealth.IsDead () == true) {
//			tAndHealth.RemoveMe();
//		}
		
		LockRotation ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Enemy") 
		{
			myTargets.Add(other.gameObject);
		}
	}

//	void OnTriggerStay(Collider other)
//	{
//		foreach (GameObject enemy in myTargets) 
//		{
//			tAndHealth = enemy.GetComponent<TargetAndHealth>();
//			if(tAndHealth.IsDead() == true)
//			{
//				tAndHealth.RemoveMe();
//			}
//		}
//	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Enemy") 
		{
			myTargets.Remove(other.gameObject);
		}
	}

	void FollowEnemy()
	{
		curEnemy = myTargets [0];
		theEnemy = curEnemy.transform;
		
		thisGun.position = Vector3.MoveTowards (theGun.transform.position, theEnemy.position, Time.deltaTime * damp);
	}
	
	void LockRotation()
	{
		Vector3 myRotation = transform.rotation.eulerAngles;
		myRotation.x = 0;
		myRotation.z = 0;
		transform.rotation = Quaternion.Euler (myRotation);
	}

	public List<GameObject> EnemyList()
	{
		return myTargets;
	}

	#region Accessors

	public float MoveSpeed()
	{
		return maxMove;
	}

	public float FireRate()
	{
		return fireRate;
	}

	public float TargetRange()
	{
		return myRadius;
	}

	public float HitDamage()
	{
		return hitDamage;
	}

	#endregion

	#region Mutators

	public void SpeedUp(float sUp)
	{
		maxMove += sUp;
		Debug.Log (maxMove);
	}

	public void RangeUp(float rUp)
	{
		myRadius += rUp;
		Debug.Log (myRadius);
	}

	public void DamageUp(float dUp)
	{
		hitDamage += dUp;
		Debug.Log (hitDamage);
	}

	public void FireUp(float fUp)
	{
		fireRate += fUp;
		Debug.Log (fireRate);
	}

	#endregion
}
