using UnityEngine;
using System.Collections;

public class ButtonPosLock : MonoBehaviour {

	[SerializeField] GameObject thisPos;
	[SerializeField] Transform thisTrans;

	// Use this for initialization
	void Start () 
	{
		thisTrans = thisPos.transform;
		gameObject.transform.position = thisTrans.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
