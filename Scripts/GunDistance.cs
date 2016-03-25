using UnityEngine;
using System.Collections;

public class GunDistance : MonoBehaviour {

//	[SerializeField] Transform gunPos;
	[SerializeField] private float xValue;

	// Use this for initialization
	void Start () 
	{
//		gunPos = this.gameObject.transform.GetChild (0);
		xValue = gameObject.GetComponent<CapsuleCollider> ().radius;
//		Vector3 myDistance = gunPos.position;
//		myDistance.x = xValue;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public float ReturnDistance()
	{
		return xValue;
	}

}
