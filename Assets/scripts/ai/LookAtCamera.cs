using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour
{
	private Camera theCamera;
	
	// Use this for initialization
	
	void Start()
	{
		theCamera = Camera.main; 
	}
	
	// Update is called once per frame
	
	void LateUpdate ()
	{
		//transform.LookAt(theCamera.transform);
		transform.rotation = theCamera.transform.rotation;
	}
}