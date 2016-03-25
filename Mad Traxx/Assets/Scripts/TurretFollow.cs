using UnityEngine;
using System.Collections;

public class TurretFollow : MonoBehaviour {

//	[SerializeField] GameObject myGun;
	[SerializeField] GameObject mainTurret;
	[SerializeField] Vector3 turretPosition;
	[SerializeField] Transform thisGun;
	[SerializeField] Quaternion gunRot;

	// Use this for initialization
	void Start () 
	{
//		myGun = this.gameObject.transform.parent.transform.GetChild(0).gameObject;
		mainTurret = this.gameObject.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
//		thisGun = myGun.transform;
//
//		transform.LookAt (thisGun, Vector3.zero);

//		gunRot = Quaternion.LookRotation (thisGun.position);
//		transform.rotation = Quaternion.Slerp(transform.rotation, gunRot, Time.deltaTime * 20);

		LockRotation ();
		LockPosition ();
	}

	void LockRotation()
	{
		Vector3 myRotation = transform.rotation.eulerAngles;
		myRotation.x = 90;
		myRotation.z = 0;
		transform.rotation = Quaternion.Euler (myRotation);
	}

	void LockPosition()
	{
		Vector3 myPostion = gameObject.transform.localPosition;
		turretPosition = mainTurret.transform.position;

		myPostion.x = 0;
		myPostion.z = 0;
		myPostion.y = turretPosition.y + 0.2f;
	}
}
