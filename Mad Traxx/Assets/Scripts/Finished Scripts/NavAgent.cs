using UnityEngine;
using System.Collections;

public class NavAgent : MonoBehaviour {

	[SerializeField] private Transform playerBase;
	[SerializeField] GameObject childCar;
	NavMeshAgent agent;

	[SerializeField] float[] speeds;

	// Use this for initialization
	void Start () {

		childCar = this.gameObject.transform.GetChild (0).gameObject;
		Transform _base = GameObject.FindGameObjectWithTag ("Base").transform;
		agent = gameObject.GetComponent<NavMeshAgent> ();
		agent.speed = speeds [Random.Range (0, speeds.Length)];
		playerBase = _base;
	}
	
	// Update is called once per frame
	void Update () {
	
		agent.SetDestination (playerBase.position);

		if (agent.speed > 4) 
		{
			childCar.GetComponent<SpriteRenderer>().color = Color.red;
		}

	}
}
