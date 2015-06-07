using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class createMAP : MonoBehaviour {
	private string TypeTile;
	private Vector3 TilePosition;
	
	// Use this for initialization
	void Start () {
		FileInfo theSourceFile = new FileInfo ("Teste.otbmUnity.txt");
		StreamReader reader = theSourceFile.OpenText();
		
		string text;
		GameObject TerrainTileMap = new GameObject();		
		do
		{
			text = reader.ReadLine();
			//Console.WriteLine(text);
			string[] arr = text.Split(new string[] { ";" }, StringSplitOptions.None);

			TilePosition = new Vector3(float.Parse(arr[1])*0.32F, float.Parse(arr[3])*3, float.Parse(arr[2])*0.32F);

			GameObject SpriteGameObject = new GameObject();
			SpriteGameObject.transform.parent = TerrainTileMap.transform;
			SpriteGameObject.transform.Rotate(90F, 0F, 0F);

			SpriteGameObject.transform.position = TilePosition;
			SpriteGameObject.AddComponent <SpriteRenderer>();

			SpriteGameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("sprites/"+arr[0], typeof(Sprite)) as Sprite;

		} while (text != null);       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}