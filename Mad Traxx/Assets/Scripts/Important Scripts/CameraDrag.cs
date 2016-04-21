/*
Camera bounds assistance:
	robertbu (username). http://answers.unity3d.com/questions/501893/calculating-2d-camera-bounds.html
*/

using UnityEngine;
using System.Collections;

public class CameraDrag : MonoBehaviour {

	[SerializeField] float dragSpeedX = 0.005f;
	[SerializeField] float dragSpeedY = 0.005f;

	private Transform camTransform;
	private Camera myCam;



    [SerializeField] float mapX = 100.0f;
    [SerializeField] float mapZ = 100.0f;

    private float minX;
    private float maxX;
    private float minZ;
    private float maxZ;

    // Use this for initialization
    void Start () 
	{
		//camTransform = transform;
		myCam = Camera.main;


        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        // Calculations assume map is position at the origin
        minX = horzExtent - mapX / 2.0f;
        maxX = mapX / 2.0f - horzExtent;
        minZ = vertExtent - mapZ / 2.0f;
        maxZ = mapZ / 2.0f - vertExtent;
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

    void LateUpdate()
    {
        Vector3 v3 = transform.position;
        v3.x = Mathf.Clamp(v3.x, minX, maxX);
        v3.z = Mathf.Clamp(v3.z, minZ, maxZ);
        transform.position = v3;
    }
}

