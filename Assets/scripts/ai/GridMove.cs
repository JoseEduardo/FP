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

	void Start () {
		anim = GetComponent<Animator> ();
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
			
			if (input != Vector2.zero) {
				if(input.x > 0){
					input.x = 0.32F;
					input.y = -0.32F;
				}else if(input.x < 0){
					input.x = -0.32F;
					input.y = 0.32F;
				}else if(input.y > 0){
					input.y = 0.32F;
					input.x = 0.32F;
				}else if(input.y < 0){
					input.y = -0.32F;
					input.x = -0.32F;
				}
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
//			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
//			                          startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);

			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x),
			                          startPosition.y, startPosition.z + System.Math.Sign(input.y));
		} else {
//			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
//			                          startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x),
			                          startPosition.y + System.Math.Sign(input.y), startPosition.z);
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