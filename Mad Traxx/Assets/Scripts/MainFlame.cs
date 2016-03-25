using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainFlame : MonoBehaviour {

	TargetAndHealth tAndHealth;
	
	[SerializeField] GameObject theFlame;
	[SerializeField] GameObject theBarrel;
	[SerializeField] GameObject turretShot;
	
	[SerializeField] float myRadius;
	[SerializeField] float damp = 1f;
	[SerializeField] float speed;
	[SerializeField] float maxMove;
	[SerializeField] float fireRate;
	
	[SerializeField] Transform thisFlame;
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
		theFlame = this.gameObject.transform.GetChild (0).gameObject;
		theBarrel = this.gameObject.transform.GetChild (1).gameObject;
		maxMove = 15f;
		speed = 3f;
		fireRate = 2f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		thisFlame = theFlame.transform;
		barrelPos = theBarrel.transform;
		numEnemies = myTargets.Count;
		
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
			
			damp += Time.deltaTime * speed;
			if(damp >= maxMove)
			{
				damp = maxMove;
			}
			
			Quaternion rotation = Quaternion.LookRotation(theEnemy.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damp);
			if(fireRate <= 0)
			{
				Instantiate(turretShot, barrelPos.position, barrelPos.rotation);
				fireRate = 2f;
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
		
		thisFlame.position = Vector3.MoveTowards (theFlame.transform.position, theEnemy.position, Time.deltaTime * 8);
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
}
