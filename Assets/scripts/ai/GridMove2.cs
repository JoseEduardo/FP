using UnityEngine;
using System.Collections;

public class GridMove2 : MonoBehaviour {
	public float speed = 2.0F;
	
	private Vector3 endPosition;
	private Animator anim;
	private float t;
	private playerStats PStats;
	private bool isMoving = false;

	private GameObject MapCtrlObj;
	private mapController MapCtrl;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		PStats = GetComponent<playerStats>();

		MapCtrlObj = GameObject.Find ("Map_Controller");
		MapCtrl = MapCtrlObj.GetComponent<mapController>();
	}
	
	// Update is called once per frame
	void Update() {
		if (!isMoving) {
			if (Input.GetKey ("right")) {
				endPosition = new Vector3 (transform.position.x + 0.50F, transform.position.y, transform.position.z - 0.50F); 
				PStats.positionTile.x = PStats.positionTile.x + 1;
				MapCtrl.redrawMap(PStats, 2);
				StartCoroutine (movePlayer (transform));
			} else if (Input.GetKey ("left")) {
				endPosition = new Vector3 (transform.position.x - 0.50F, transform.position.y, transform.position.z + 0.50F); 
				PStats.positionTile.x = PStats.positionTile.x + 1;
				MapCtrl.redrawMap(PStats, 0);
				StartCoroutine (movePlayer (transform));
			} else if (Input.GetKey ("up")) {
				endPosition = new Vector3 (transform.position.x + 0.64F, transform.position.y, transform.position.z + 0.64F); 
				PStats.positionTile.y = PStats.positionTile.y - 1;
				MapCtrl.redrawMap(PStats, 1);
				StartCoroutine (movePlayer (transform));
			} else if (Input.GetKey ("down")) {
				endPosition = new Vector3 (transform.position.x - 0.64F, transform.position.y, transform.position.z - 0.64F); 
				PStats.positionTile.y = PStats.positionTile.y - 1;
				MapCtrl.redrawMap(PStats, 3);
				StartCoroutine (movePlayer (transform));
			}else{
				anim.Play("Idle");
			}
		}
	}   

	public IEnumerator movePlayer(Transform transform){
		isMoving = true;
		//MapCtrl.drawAllMap(PStats);
		transform.LookAt (endPosition);

		t = 0;
		while (t < 1f) {
			t += Time.deltaTime * (speed);

			anim.Play("Walk");
			transform.position = Vector3.Lerp(transform.position, endPosition, t);
			yield return null;
		}

		isMoving = false;
		yield return 0;
	}

}
