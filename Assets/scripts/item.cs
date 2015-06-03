using UnityEngine;
using System.Collections;

public class item : MonoBehaviour {
	private bool guiIsOn = false;

	public string descItem;
	private string descItemComp;
	public int Qtd = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && Input.GetMouseButtonDown(1)) {
			guiIsOn = true;
			TurnOffGUIInSeconds(3);
		}

		if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1)) {
			guiIsOn = true;
			TurnOffGUIInSeconds(3);
		}

	}

	private void TurnOffGUIInSeconds(int seconds)
	{
		StartCoroutine(_TurnOffGUIInSeconds(seconds));
	}
	
	private IEnumerator _TurnOffGUIInSeconds(int seconds)
	{
		yield return new WaitForSeconds(seconds);
		guiIsOn = false;
	}
	
	void OnGUI()
	{
		if(guiIsOn)
		{
			if(Qtd <= 1){
				descItemComp = "You see a "+descItem+".";
				GUI.Label(new Rect( (Screen.width-descItemComp.Length)/2, Screen.height/2, 1000, 100), "<b><color=lime><size=12>"+descItemComp+"</size></color></b>");
			}else{
				descItemComp = "You see an "+Qtd+" "+descItem+".";
				GUI.Label(new Rect( (Screen.width-descItemComp.Length)/2, Screen.height/2, 1000, 100), "<b><color=lime><size=12>"+descItemComp+"</size></color></b>");
			}
		}
	}


}
