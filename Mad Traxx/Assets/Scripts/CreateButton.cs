using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateButton : MonoBehaviour {
	
	[SerializeField] private Transform[] buttonSpots;
	[SerializeField] GameObject myButton;

	// Use this for initialization
	void Start () {
	
		GameObject[] makeButton = GameObject.FindGameObjectsWithTag("ButtonSpot");
		buttonSpots = new Transform[makeButton.Length];

		for (int i = 0; i < makeButton.Length; ++i) 
		{
			buttonSpots[i] = makeButton[i].transform;
		}

		foreach (Transform thisSpot in buttonSpots) 
		{
			Instantiate(myButton, thisSpot.position, thisSpot.rotation);
			myButton.transform.SetParent(this.gameObject.transform);
		}

	}
	
	// Update is called once per frame
	void Update () {


	}

//	void CreateHere(Transform _bSpot)
//	{
//
//	}
}
