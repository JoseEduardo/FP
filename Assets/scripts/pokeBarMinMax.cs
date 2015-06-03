using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pokeBarMinMax : MonoBehaviour {
	private bool Maximized = true;
	private Button button;

	public GameObject Content = null;
	public Sprite MaxSprite;
	public Sprite MinSprite;

	void Start(){
		button = GetComponent<Button>();
	}

	public void MinimizeMaximize(){
		if (Maximized) {
			Content.SetActive(false);
			button.image.overrideSprite = MaxSprite;
			Maximized = false;
		} else {
			Content.SetActive(true);
			button.image.overrideSprite = MinSprite;
			Maximized = true;
		}

	}
}
