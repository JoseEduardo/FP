using UnityEngine;
using System.Collections;

public class GuiHealth : MonoBehaviour {
	public Vector2 pos = new Vector2(20,40);
	public Vector2 size = new Vector2(60,20);
	public float adjustment = 2.3F;

	public Vector2 posName = new Vector2(20,40);
	public Vector2 sizeName = new Vector2(60,20);
	public int sizeFontName = 20;
	public string sizeFontColor = "green";

	public Texture2D emptyTex;
	public Texture2D fullTex;


	private Vector3 worldPosition = new Vector3();
	private Vector3 screenPosition = new Vector3();
	private Transform myTransform;
	private Camera myCamera;

	private playerStats pStatus;

	void Start(){
		pStatus = GetComponent<playerStats> ();
	}

	void Awake()
	{
		myTransform = transform;
		myCamera = Camera.main;
	}

	void OnGUI() {
		worldPosition = new Vector3(myTransform.position.x, myTransform.position.y + adjustment,myTransform.position.z);
		screenPosition = myCamera.WorldToScreenPoint(worldPosition);

		GUI.BeginGroup(new Rect(screenPosition.x -pos.x  / 2, Screen.height - screenPosition.y - pos.y, size.x, size.y), GUIStyle.none);
			GUI.Box(new Rect(0,0, size.x, size.y), emptyTex, GUIStyle.none);
			GUI.BeginGroup(new Rect(0,0, pStatus.Health, size.y), GUIStyle.none);
				GUI.Box(new Rect(0,0, size.x, size.y), fullTex, GUIStyle.none);
			GUI.EndGroup();
		GUI.EndGroup();

		GUI.Label(new Rect(screenPosition.x - posName.x / 2, Screen.height - screenPosition.y -posName.y, sizeName.x, sizeName.y+20), "<b><color="+sizeFontColor+"><size="+sizeFontName+">"+pStatus.PlayerName+"</size></color></b>");
	}

}