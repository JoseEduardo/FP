using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerStats : MonoBehaviour {
	public Transform Pokemon = null;
	public string PokemonName = "";
	public string PlayerName = "";
	public TextMesh ObgPName = null;
	public Vector3 positionTile;
	private Vector3 posRespawnTile;
	public List<tileMap> ListTileMap = null;

	public int Health = 100;
	public int MaxHealth = 100;

	private RaycastHit hit;
	private Ray ray;
	
	private Vector3 positionTarget;
	public GameObject TargetIcon;
	public GameObject Target = null;
	private GameObject TargetCr = null;

	private float timeLeft = 0.5F;
	private NavMeshAgent agent;

	private GameObject MapCtrlObj;
	private mapController MapCtrl;

	private pokeChase pChase;

	void Start(){
		posRespawnTile = new Vector3(positionTile.x*0.32F, (positionTile.z -7) * 3F, positionTile.y*0.32F);
		transform.position = posRespawnTile;

		pChase = GetComponent<pokeChase> ();
		agent = GetComponent<NavMeshAgent>();

		MapCtrlObj = GameObject.Find ("Map_Controller");
		MapCtrl = MapCtrlObj.GetComponent<mapController>();

		MapCtrl.drawAllMap(this);
	}

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if ( timeLeft < 0 )
		{
			agent.enabled = true;
		}

		if (ObgPName != null) {
			ObgPName.text = PlayerName;
		}

		if ( Input.GetMouseButtonDown(0)){
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 100.0F)){
				if( hit.collider.transform.tag == "Pokemon" && hit.collider.gameObject.transform != Pokemon ){
					if(TargetCr != null){
						Destroy( TargetCr);
					}

					if(hit.collider.gameObject != Target){
						//-(hit.collider.transform.localScale.x/2)
						positionTarget = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, hit.collider.transform.position.z);
						TargetCr = Instantiate(TargetIcon, positionTarget, Quaternion.identity) as GameObject;
						TargetCr.transform.parent = hit.collider.gameObject.transform;
						pChase.leader = hit.collider.gameObject.transform;

						Target = hit.collider.gameObject;
					}else{
						pChase.leader = transform;
						Target = null;
					}

				}
			}
		}
	}
}
