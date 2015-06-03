using UnityEngine;
using System.Collections;

public class ClearSight : MonoBehaviour {
	
	public float DistanceToPlayer = 100.0f;
	public Material TransparentMaterial = null;
	public float FadeInTimeout = 0.6f;
	public float FadeOutTimeout = 0.2f;
	public float TargetTransparency = 0.3f;
	public GameObject CameraP;
	public GameObject Target;
	
	private void Update() {
		RaycastHit[] hits; // you can also use CapsuleCastAll() 
		
		// TODO: setup your layermask it improve performance and filter your hits. 
		hits = Physics.RaycastAll(transform.position, Target.transform.position, DistanceToPlayer);

		Debug.DrawLine (transform.position,  Target.transform.position, Color.red);
		//CameraP.transform.position
		foreach (RaycastHit hit in hits) {
			//precisa add todos menos os que esta se colidindo
			CameraP.GetComponent<Camera>().cullingMask = 1 << LayerMask.NameToLayer("MiniMap");
			/*
			Renderer R = hit.collider.GetComponent<Renderer>();
			if (R == null) {
				continue;
			}

			AutoTransparent AT = R.GetComponent<AutoTransparent>();
			
			if (AT == null)
			{
				AT = R.gameObject.AddComponent<AutoTransparent>();
				
				AT.TransparentMaterial = TransparentMaterial;
				AT.FadeInTimeout = FadeInTimeout;
				AT.FadeOutTimeout = FadeOutTimeout;
				AT.TargetTransparency = TargetTransparency;
			}
			
			AT.BeTransparent();
			*/
		}
	}
}
