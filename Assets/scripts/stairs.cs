using UnityEngine;
using System.Collections;

public class stairs : MonoBehaviour {
	public Transform ToPos = null;
	private playerStats PlayerStats;
	private Transform PlayerPoke = null;
	private GridMove GrdMove;

	void OnCollisionStay(Collision collision) {
		if( collision.gameObject.transform.tag == "Player" ){
			GrdMove = collision.gameObject.GetComponent<GridMove>();
			GrdMove.Teleport = true;

			collision.gameObject.transform.position = ToPos.position;
			PlayerStats = collision.gameObject.GetComponent<playerStats>();
			PlayerPoke = PlayerStats.Pokemon;
			if(PlayerPoke != null){
				PlayerPoke.position = ToPos.position;
			}
			GrdMove.Teleport = false;

		}
	}

}