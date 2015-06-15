using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class mapController : MonoBehaviour {
	private StreamReader reader;
	private string text;
	private tileMap TMap;
	public List<tileMap> ListTileMap;
	private GameObject TerrainContainer = null;
	private int IDTiles = 0;
	public float MaxTiles = 10F;

	// Use this for initialization
	void Start () {
		FileInfo theSourceFile = new FileInfo ("Teste.otbmUnity.txt");
		reader = theSourceFile.OpenText();

		ListTileMap = new List<tileMap> ();
		do
		{
			TMap = new tileMap();
			text = reader.ReadLine();

			string[] arr = text.Split (new string[] { ";" }, StringSplitOptions.None);
			TMap.ID = IDTiles;
			TMap.SpriteID = arr [0];
			TMap.posX = Convert.ToInt32(arr[1]);
			TMap.posY = Convert.ToInt32(arr[2]);
			TMap.posZ = Convert.ToInt32(arr[3]);
			ListTileMap.Add(TMap);
			IDTiles += 1;
		} while (text != null);
	}

	public void redrawMap(playerStats Player, int dir){
		/*
		0 - left
		1 - up
		2 - right
		3- down
		*/
	}

	public void drawAllMap(playerStats Player){

		if (TerrainContainer != null) {
			Destroy (TerrainContainer);
		}

		TerrainContainer = new GameObject ();
		TerrainContainer.transform.parent = Player.transform.parent.transform;
		TerrainContainer.transform.localPosition = new Vector3 (-1F, 0.08F, -17.4F);
		TerrainContainer.transform.Rotate (0F, -44.49991F, -0.2049561F);

		Vector3 posPlayer = Player.positionTile; 
		int MaxX = (int)Math.Round(posPlayer.x+MaxTiles);
		int MinX = (int)Math.Round(posPlayer.x-MaxTiles);

		int MaxY = (int)Math.Round(posPlayer.y+MaxTiles);
		int MinY = (int)Math.Round(posPlayer.y-MaxTiles);

		//DEPRECATED VERIFICAR COMO FAZER PARA N DAR O LAGG, TALVEZ QUEBRAR EM VARIOS E PROCURAR DEPOIS
		Player.ListTileMap = ListTileMap.FindAll(tile => tile.posX >= MinX && tile.posX <= MaxX && tile.posY >= MinY && tile.posY <= MaxY && tile.posZ <= posPlayer.z);

		int CtrlX = Player.ListTileMap [0].posX;
		int CtrlY = Player.ListTileMap [0].posY;

		for (int i = 0; i < Player.ListTileMap.Count; i++) {
			GameObject SpriteGameObject = new GameObject ();
			SpriteGameObject.transform.parent = TerrainContainer.transform;

			SpriteGameObject.transform.Rotate (-90F, 135F, 0F);
			SpriteGameObject.transform.localPosition = new Vector3 ( (Player.ListTileMap [i].posX-CtrlX) * 0.64F, (Player.ListTileMap [i].posZ - 7) * 3, (Player.ListTileMap [i].posY-CtrlY) * 0.64F);
			SpriteGameObject.transform.name = i.ToString();
		
			SpriteGameObject.AddComponent <SpriteRenderer> ();			
			SpriteGameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("sprites/" + Player.ListTileMap [i].SpriteID, typeof(Sprite)) as Sprite;
			SpriteGameObject.transform.tag = "Tile";
		
			SpriteGameObject.transform.localScale = new Vector3 (2F, 2F, 1F);
		}
	}
}
