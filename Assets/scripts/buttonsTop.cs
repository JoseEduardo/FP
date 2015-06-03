using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonsTop : MonoBehaviour {
	public bool Showing = false;
	private Button button;
	
	public GameObject Content = null;
	public Sprite On;
	public Sprite Off;
	
	void Start(){
		button = GetComponent<Button>();
	}
	
	public void ShowHide(){
		if (Showing) {
			Content.SetActive(false);
			button.image.overrideSprite = On;
			Showing = false;
		} else {
			Content.SetActive(true);
			button.image.overrideSprite = Off;
			Showing = true;
		}
		
	}
}
