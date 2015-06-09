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
	public GameObject TerrainContainer;
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
		List<tileMap> tileTempDel;
		List<tileMap> tileTempAdd;
		Vector3 posPlayer = Player.positionTile; 
		if (dir == 0) {
			int limitPos = (int)Math.Round (Player.positionTile.x + 10F);
			tileTempDel = Player.ListTileMap.FindAll (tile => tile.posX >= limitPos);

			int MaxX = (int)Math.Round(posPlayer.x-MaxTiles);
			int MaxY = (int)Math.Round(posPlayer.y+MaxTiles);
			int MinY = (int)Math.Round(posPlayer.y-MaxTiles);
			tileTempAdd = ListTileMap.FindAll(tile => tile.posX == MaxX && tile.posY <= MaxY && tile.posY >= MinY && tile.posZ <= posPlayer.z);
		} else if (dir == 1) {
			int limitPos = (int)Math.Round (Player.positionTile.y - 10F);
			tileTempDel = Player.ListTileMap.FindAll (tile => tile.posY <= limitPos);

			int MaxY = (int)Math.Round(posPlayer.y+MaxTiles);
			int MaxX = (int)Math.Round(posPlayer.x+MaxTiles);
			int MinX = (int)Math.Round(posPlayer.x-MaxTiles);
			tileTempAdd = ListTileMap.FindAll(tile => tile.posY == MaxY && tile.posX <= MaxX && tile.posX >= MinX && tile.posZ <= posPlayer.z);
		} else if (dir == 2) {
			int limitPos = (int)Math.Round (Player.positionTile.x - 10F);
			tileTempDel = Player.ListTileMap.FindAll (tile => tile.posX <= limitPos);

			int MaxX = (int)Math.Round(posPlayer.x+MaxTiles);
			int MaxY = (int)Math.Round(posPlayer.y+MaxTiles);
			int MinY = (int)Math.Round(posPlayer.y-MaxTiles);
			tileTempAdd = ListTileMap.FindAll(tile => tile.posX == MaxX && tile.posY <= MaxY && tile.posY >= MinY && tile.posZ <= posPlayer.z);		
		} else {
			int limitPos = (int)Math.Round (Player.positionTile.y + 10F);
			tileTempDel = Player.ListTileMap.FindAll (tile => tile.posY >= limitPos);

			int MaxY = (int)Math.Round(posPlayer.y-MaxTiles);
			int MaxX = (int)Math.Round(posPlayer.x+MaxTiles);
			int MinX = (int)Math.Round(posPlayer.x-MaxTiles);
			tileTempAdd = ListTileMap.FindAll(tile => tile.posY == MaxY && tile.posX <= MaxX && tile.posX >= MinX && tile.posZ <= posPlayer.z);		
		}
		/*
		for (int i = 0; i < tileTempDel.Count; i++) {
			if(tileTempDel[i].Tile != null){
				Destroy(tileTempDel[i].Tile);
			}
		}
		*/
		for (int i = 0; i < tileTempAdd.Count; i++) {
			GameObject SpriteGameObject = new GameObject ();
			SpriteGameObject.transform.position = new Vector3 (tileTempAdd [i].posX * 0.32F, (tileTempAdd [i].posZ - 7) * 3, tileTempAdd [i].posY * 0.32F);
			SpriteGameObject.transform.Rotate (-90F, 0F, 0F);
			SpriteGameObject.transform.name = tileTempAdd [i].SpriteID;
			
			SpriteGameObject.AddComponent <SpriteRenderer> ();			
			SpriteGameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("sprites/" + tileTempAdd [i].SpriteID, typeof(Sprite)) as Sprite;
			SpriteGameObject.transform.tag = "Tile";
			
			SpriteGameObject.transform.localScale = new Vector3 (2F, 2F, 1F);
			SpriteGameObject.transform.parent = TerrainContainer.transform;
			Player.ListTileMap [i].Tile = SpriteGameObject;
		}


	}

	public void drawAllMap(playerStats Player){
		/*
		if (Player.ListTileMap != null) {
			for (int x = 0; x < Player.ListTileMap.Count; x++) {
				Player.ListTileMap.RemoveAt (x);
			}
		}
		*/
		Vector3 posPlayer = Player.positionTile; 
		int MaxX = (int)Math.Round(posPlayer.x+MaxTiles);
		int MinX = (int)Math.Round(posPlayer.x-MaxTiles);

		int MaxY = (int)Math.Round(posPlayer.y+MaxTiles);
		int MinY = (int)Math.Round(posPlayer.y-MaxTiles);

		Player.ListTileMap = ListTileMap.FindAll(tile => tile.posX >= MinX && tile.posX <= MaxX && tile.posY >= MinY && tile.posY <= MaxY && tile.posZ <= posPlayer.z);
		for (int i = 0; i < Player.ListTileMap.Count; i++) {
			GameObject SpriteGameObject = new GameObject ();
			SpriteGameObject.transform.position = new Vector3 (Player.ListTileMap [i].posX * 0.32F, (Player.ListTileMap [i].posZ - 7) * 3, Player.ListTileMap [i].posY * 0.32F);
			SpriteGameObject.transform.Rotate (-90F, 0F, 0F);
			SpriteGameObject.transform.name = Player.ListTileMap [i].SpriteID;
		
			SpriteGameObject.AddComponent <SpriteRenderer> ();			
			SpriteGameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("sprites/" + Player.ListTileMap [i].SpriteID, typeof(Sprite)) as Sprite;
			SpriteGameObject.transform.tag = "Tile";
		
			SpriteGameObject.transform.localScale = new Vector3 (2F, 2F, 1F);
			SpriteGameObject.transform.parent = TerrainContainer.transform;
			Player.ListTileMap [i].Tile = SpriteGameObject;
		}
	}
}
