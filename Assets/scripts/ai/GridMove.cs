using System.Collections;
using UnityEngine;

class GridMove : MonoBehaviour {
	public float moveSpeed = 3f;
	public float gridSize = 1f;
	public bool Teleport = false;
	private enum Orientation {
		Horizontal,
		Vertical
	};
	private Orientation gridOrientation = Orientation.Horizontal;
	public bool allowDiagonals = false;
	public bool correctDiagonalSpeed = true;
	private Vector2 input;
	private bool isMoving = false;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private float t;
	private float factor;
	private Animator anim;

	private playerStats PStats;

	private GameObject MapCtrlObj;
	private mapController MapCtrl;

	void Start () {
		anim = GetComponent<Animator> ();

		PStats = GetComponent<playerStats>();
		
		MapCtrlObj = GameObject.Find ("Map_Controller");
		MapCtrl = MapCtrlObj.GetComponent<mapController>();
	}

	public void Update() {
		if (!isMoving) {
			//input = new Vector2(Input.GetAxis("Horizontal")*-1, Input.GetAxis("Vertical")*-1);
			input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			if (!allowDiagonals) {
				if (Mathf.Abs(input.x) > Mathf.Abs(input.y)) {
					input.y = 0;
				} else {
					input.x = 0;
				}
			}

			if (input != Vector2.zero) { // HORIZONTAL
				if(input.x > 0){
					input.x = 0.32F;
					input.y = -0.32F;
					PStats.positionTile.y = PStats.positionTile.y - 1;
					//MapCtrl.redrawMap(PStats, 2);
				}else if(input.x < 0){ // HORIZONTAL
					input.x = -0.32F;
					input.y = 0.32F;
					PStats.positionTile.y = PStats.positionTile.y + 1;
					//MapCtrl.redrawMap(PStats, 0);
				}else if(input.y > 0){ // VERTICAL
					input.y = 0.32F;
					input.x = 0.32F;
					PStats.positionTile.x = PStats.positionTile.x + 1;
					//MapCtrl.redrawMap(PStats, 3);
				}else if(input.y < 0){ // VERTICAL
					input.y = -0.32F;
					input.x = -0.32F;
					PStats.positionTile.x = PStats.positionTile.x - 1;
					//MapCtrl.redrawMap(PStats, 1);
				}
				MapCtrl.drawAllMap(PStats);
				StartCoroutine(move(transform));
			}else{
				anim.Play("Idle");
			}
		}
	}
	
	public IEnumerator move(Transform transform) {
		isMoving = true;
		startPosition = transform.position;
		t = 0;
		
		if(gridOrientation == Orientation.Horizontal) {
			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
			                          startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);
		} else {
			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
			                          startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
		}
		
		if(allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0) {
			factor = 0.7071f;
		} else {
			factor = 1f;
		}
		
		while (t < 1f) {
			if(isMoving){
				if(!Teleport){
					t += Time.deltaTime * (moveSpeed/gridSize) * factor;

					transform.LookAt (endPosition);
					anim.Play("Walk");
					transform.position = Vector3.Lerp(startPosition, endPosition, t);
					yield return null;
				}else{
					anim.Play("Idle");
					break;
				}
			}else{
				t = 1f;
			}
		}

		isMoving = false;
		yield return 0;
	}

	void OnDisable() {
		isMoving = false;
		anim.Play("Idle");
	}

}