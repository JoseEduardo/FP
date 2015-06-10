using UnityEngine;
using System.Collections;
using UnityStandardAssets.Utility;

public class Controller : MonoBehaviour {
	public GameObject PlayerPrefab;
	public Vector3 positionPlayer;
	public GameObject IsoCamera;
	private GameObject Player;

	// Use this for initialization
	void Start () {
		Player =  Instantiate(PlayerPrefab, new Vector3(positionPlayer.x*0.32F, (positionPlayer.z-7)*3F, positionPlayer.y*0.32F) , Quaternion.identity) as GameObject;
		Player.GetComponent<playerStats> ().positionTile = positionPlayer;

		IsoCamera.GetComponent<SmoothFollow> ().target = Player.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
