using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {
	public Transform Pokemon = null;
	public string PokemonName = "";
	public string PlayerName = "";
	public TextMesh ObgPName = null;

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

	private pokeChase pChase;

	void Start(){
		pChase = GetComponent<pokeChase> ();
		agent = GetComponent<NavMeshAgent>();
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
