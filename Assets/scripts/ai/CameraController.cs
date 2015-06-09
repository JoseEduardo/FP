using UnityEngine;
using System.Collections;

// Camera Controller
// Revision 2
// Allows the camera to move left, right, up and down along a fixed axis.
// Attach to a camera GameObject (e.g MainCamera) for functionality.

public class CameraController : MonoBehaviour {
	
	// How fast the camera moves
	int cameraVelocity = 10;
	
	// Use this for initialization
	void Start () {
		
		// Set the initial position of the camera.
		// Right now we don't actually need to set up any other variables as
		// we will start with the initial position of the camera in the scene editor
		// If you want to create cameras dynamically this will be the place to
		// set the initial transform.positiom.x/y/z
	}
	
	// Update is called once per frame
	void Update () {
		// Left
		if((Input.GetKey(KeyCode.LeftArrow)))
		{
			transform.Translate((Vector3.left* cameraVelocity) * Time.deltaTime);
		}
		// Right
		if((Input.GetKey(KeyCode.RightArrow)))
		{
			transform.Translate((Vector3.right * cameraVelocity) * Time.deltaTime);
		}
		// Up
		if((Input.GetKey(KeyCode.UpArrow)))
		{
			transform.Translate((Vector3.up * cameraVelocity) * Time.deltaTime);
		}
		// Down
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate((Vector3.down * cameraVelocity) * Time.deltaTime);
		}
	}
}