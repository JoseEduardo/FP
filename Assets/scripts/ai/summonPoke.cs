using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class summonPoke : MonoBehaviour {
	public Transform Pokeball;
	public Transform Pokemon = null;
	public string PokeName = "";

	private Transform PokemonPlayer;
	private Transform PokemonC;

	private Vector3 positionPoke;
//	private Vector3 positionPokeball;

	private bool pokeIn = true;
	private playerStats PlayerStats;
			
	// Use this for initialization
	public void SummonPokemon(Transform Player) {
		if (pokeIn) {
			PlayerStats = Player.GetComponent<playerStats>();
			positionPoke = new Vector3(Player.position.x+1F, Player.position.y, Player.position.z+1F);
//			positionPokeball = new Vector3(positionPoke.x, positionPoke.y+10F, positionPoke.z);

			//LANCA POKEBALL
	//		PokemonC = (Transform)Instantiate(Pokeball, positionPoke, Quaternion.identity);
	//		Destroy(PokemonC.gameObject, 2F);

			PokemonPlayer = (Transform)Instantiate(Pokemon, positionPoke, Quaternion.identity);

			PlayerStats.Pokemon = PokemonPlayer;
			PlayerStats.PokemonName = PokeName;
			pokeIn = false;
		} else {
			PlayerStats.Pokemon = null;
			Destroy( PokemonPlayer.gameObject );
			pokeIn = true;
		}

	}


}
