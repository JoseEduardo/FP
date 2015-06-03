using UnityEngine;
using System.Collections;

public class targetAnim : MonoBehaviour {
	private float delay = 0.08F;
	private float curr_delay;

	void Start(){
		transform.localScale = new Vector3(0F, transform.localScale.y, 0F );
	}

	// Update is called once per frame
	void Update () {
		if (curr_delay <= Time.time) {
			if(transform.localScale.x < 1.7F){
				transform.localScale = new Vector3(transform.localScale.x + 0.1F, transform.localScale.y, transform.localScale.z + 0.1F );
			}else{
				transform.localScale = new Vector3(0F, transform.localScale.y, 0F );
			}
		
			curr_delay = Time.time + delay;
		}

	}
}