using UnityEngine;
using System.Collections;

public class CameraDrag : MonoBehaviour {

	[SerializeField] float dragSpeedX = 0.005f;
	[SerializeField] float dragSpeedY = 0.005f;

	private Transform camTransform;
	private Camera myCam;

	// Use this for initialization
	void Start () 
	{
		//camTransform = transform;
		myCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Touch[] touches = Input.touches;

		if (touches.Length == 1) 
		{
			if(touches[0].phase == TouchPhase.Moved)
			{
				Vector2 delta = touches[0].deltaPosition;

				float positionX = delta.x + dragSpeedX * Time.deltaTime * 0.5f;
				float positionY = delta.y + dragSpeedY * Time.deltaTime * 0.5f;

				myCam.transform.position += new Vector3(positionX * -1, 0, positionY * -1);
			}
		}
	}
}

