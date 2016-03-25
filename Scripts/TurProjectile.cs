using UnityEngine;
using System.Collections;

public class TurProjectile : MonoBehaviour {

	[SerializeField] float projectileSpeed;
	[SerializeField] float killTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		killTimer += Time.deltaTime;
		transform.Translate (Vector3.forward * projectileSpeed * Time.deltaTime, Space.Self);
		if (killTimer > 2) 
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			Destroy(gameObject);
		}
	}
}
