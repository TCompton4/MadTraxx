using UnityEngine;
using System.Collections;

public class TurretRay : MonoBehaviour {

	[SerializeField] GameObject myParent;
//	[SerializeField] GameObject myGun;

	[SerializeField] float myRadius;
	
	void Start () 
	{
		myParent = gameObject.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		myRadius = myParent.GetComponent<CapsuleCollider> ().radius;
		
//		RaycastHit hit;
		Vector3 target = transform.TransformDirection(Vector3.right) * myRadius * 3.8f;
		
		Debug.DrawRay (transform.position, target, Color.green);
	}


}
