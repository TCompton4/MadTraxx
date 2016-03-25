using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour {

	[SerializeField] float startHealth = 200f;
	[SerializeField] float barAmount = 1f;
	[SerializeField] float baseHealth = 200f;
	[SerializeField] Image healthBar;
	[SerializeField] float showHealth;

	// Use this for initialization
	void Start () 
	{
		baseHealth = startHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		healthBar.fillAmount = baseHealth * (barAmount / startHealth);
		showHealth = healthBar.fillAmount;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy") 
		{
			Destroy(other.gameObject);
			baseHealth -= 35f;
			Debug.Log(showHealth);
		}
	}
	
}
