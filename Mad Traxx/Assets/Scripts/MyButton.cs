using UnityEngine;
using System.Collections;

public class MyButton : MonoBehaviour {

	[SerializeField] Transform thisSpot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.gameObject.transform.position = thisSpot.position;
		this.gameObject.transform.localScale = thisSpot.localScale;
	}
}
