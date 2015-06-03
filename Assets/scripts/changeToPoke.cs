using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class changeToPoke : MonoBehaviour {
	private playerStats PlayerStats;
	private Transform PlayerPoke;

	private Rigidbody RigidbodyPoke;

	private GridMove GridMovePoke;
	private GridMove GridMovePlayer;

	private pokeChase PkChase;
	private Animator anim;

	void Start() {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			PlayerStats = GetComponent<playerStats>();
			PlayerPoke = PlayerStats.Pokemon;

			GridMovePlayer = GetComponent<GridMove>();
			GridMovePoke = PlayerPoke.GetComponent<GridMove>();

			GridMovePoke.enabled = false;

			PkChase = GetComponent<pokeChase>();

			//PLAYER
			if (GridMovePlayer.enabled) {
				PkChase.Active = false;
				GridMovePlayer.enabled = false;

				GridMovePoke.enabled = true;
			//POKEMON
			}else{
				GridMovePoke.enabled = false;

				PkChase.Active = true;
				GridMovePlayer.enabled = true;			
			}

			anim.Play("Idle");
		}
	}
}
