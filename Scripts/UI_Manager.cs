using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

	[SerializeField] GameObject cancelButton;

	// Use this for initialization
	void Start () 
	{
		cancelButton = GameObject.FindGameObjectWithTag ("Cancel");
		cancelButton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
