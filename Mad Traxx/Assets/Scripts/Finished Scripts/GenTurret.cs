using UnityEngine;
using System.Collections;

public class GenTurret : MonoBehaviour {

	[SerializeField] private Transform thisSpot;
	[SerializeField] GameObject myTurret;

	[SerializeField] private bool noTurret;

	// Use this for initialization
	void Start () 
	{
		noTurret = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateTurret()
	{
		if (noTurret == true) 
		{
			Instantiate (myTurret, thisSpot.position, transform.rotation);
			noTurret = false;
		}
	}
}
