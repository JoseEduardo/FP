using UnityEngine;
using System.Collections;
using UnityStandardAssets.Utility;

public class Controller : MonoBehaviour {
	public GameObject PlayerPrefab;
	public Vector3 positionPlayer;
	public GameObject IsoCamera;
	private GameObject Player;
	private GameObject PlayerBody;

	// Use this for initialization
	void Start () {
		Player =  Instantiate(PlayerPrefab, new Vector3(positionPlayer.x*0.32F, (positionPlayer.z-7)*3F, positionPlayer.y*0.32F) , Quaternion.identity) as GameObject;

		PlayerBody = Player.transform.FindChild("Body").gameObject;
		PlayerBody.GetComponent<playerStats> ().positionTile = positionPlayer;

		IsoCamera.AddComponent <AstarSmoothFollow2> ();	
		IsoCamera.GetComponent<AstarSmoothFollow2> ().rotationDamping = 0;
		IsoCamera.GetComponent<AstarSmoothFollow2> ().distance = -2.16F;
		IsoCamera.GetComponent<AstarSmoothFollow2> ().height = 4.05F;
		IsoCamera.GetComponent<AstarSmoothFollow2> ().damping = 3F;

		IsoCamera.GetComponent<AstarSmoothFollow2> ().target = PlayerBody.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
