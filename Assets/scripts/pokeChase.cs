using UnityEngine;
using System.Collections;

public class pokeChase : MonoBehaviour {
	public float speed = 2.0F;
	public float chaseRange = 1.0F;
	public float MaxRange = 6F;
	public Transform follower = null;
	public bool Active = true;
	private playerStats PlayerStats;
	public Transform leader = null;
	private float range;

	// Update is called once per frame
	void Start(){
		leader = transform;

		PlayerStats = GetComponent<playerStats>();
	}

	void Update () {
		if (Active) {
			follower = PlayerStats.Pokemon;
			if (follower != null) {
				range = Vector3.Distance (follower.position, leader.position);

				if (range < MaxRange) {
					if (range >= chaseRange) {
						follower.LookAt (leader);
						//follower.position = Vector3.Lerp(startPosition, endPosition, Time.deltaTime * (speed/1) * 0.7071f);
						follower.Translate (speed * Vector3.forward * Time.deltaTime);
					}else{
						return;
					}

				}else{
					follower.position = leader.position;
				}

			}
		}
	}



}
