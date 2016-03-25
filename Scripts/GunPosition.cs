using UnityEngine;
using System.Collections;

public class GunPosition : MonoBehaviour {
	
	[SerializeField] Transform parentOBJ;
	[SerializeField] GameObject thisOBJ;
	[SerializeField] GunDistance myGun;

	// Use this for initialization
	void Start () 
	{
		thisOBJ = gameObject;
		myGun = gameObject.transform.parent.GetComponent<GunDistance> ();
		parentOBJ = gameObject.transform.parent.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
	{
//		GameObject thisOBJ = new GameObject ();
		thisOBJ.transform.parent = parentOBJ.transform;
		thisOBJ.transform.localPosition = new Vector3 (myGun.ReturnDistance (), 0, 0);
//		Vector3 newPosition = new Vector3 (thisOBJ.transform.localPosition.x + myDis, 0, 0);
//		thisOBJ.transform.position = newPosition;
	}

//	void HoldPosition()
//	{
//		Vector3 newPosition = new Vector3 (transform.position.x + myDis, 0, 0);
//	}
}
