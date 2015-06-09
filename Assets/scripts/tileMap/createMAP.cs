using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;	
#endif

public class createMAP : MonoBehaviour {
	private string TypeTile;
	private Vector3 TilePosition;
	private StreamReader reader;
	private string text;
	private GameObject TerrainTileMap;
	private List<string> ListTiles;
	private float Floor;

	public int StartLine = 0;
	public int QtdLine = 5000;
	public int CurrLine = 0;
	public bool Liberado = false;
	public UnityEngine.Object emptyObj;
	private int CountPF = 0;

	public float updateInterval = 0.5F;
	private double lastInterval;
	
	// Use this for initialization
	void Start () {
		FileInfo theSourceFile = new FileInfo ("Teste.otbmUnity.txt");
		reader = theSourceFile.OpenText();
/*		
		TerrainTileMap = new GameObject();		
		TerrainTileMap.transform.name = "Terrain";
		TerrainTileMap.SetActive (false);

		#if UNITY_EDITOR
		string fileName = "empty_object_1";
		string fileLocation = "Assets/Resources/prefabs/"+fileName+".prefab";
		emptyObj = PrefabUtility.CreateEmptyPrefab(fileLocation);
		#endif
*/
		ListTiles = new List<string> ();
		do
		{
			text = reader.ReadLine();
			ListTiles.Add(text);
		} while (text != null);

		lastInterval = Time.realtimeSinceStartup;
		print ("START");
		//Liberado = true;
	}
	
	// Update is called once per frame
	void Update () {
		float timeNow = Time.realtimeSinceStartup;
		if (timeNow > lastInterval + updateInterval) {
			if(QtdLine < ListTiles.Count){
				////
				TerrainTileMap = new GameObject();		
				TerrainTileMap.transform.name = "Terrain_"+QtdLine;
				TerrainTileMap.SetActive (false);

				#if UNITY_EDITOR
				string fileName = "map_object_"+CountPF;
				string fileLocation = "Assets/Resources/prefabs/"+fileName+".prefab";
				emptyObj = PrefabUtility.CreateEmptyPrefab(fileLocation);
				#endif
				////
				QtdLine = QtdLine+5000;
				Liberado = true;
			}else if(QtdLine == ListTiles.Count){
				print ("TERMINOU");
			}else{
				QtdLine = ListTiles.Count-QtdLine;
			}
		}

		if (Liberado) {
			print (CurrLine+" | "+QtdLine);

			while (CurrLine <= QtdLine) {

				text = ListTiles [CurrLine];
				//Console.WriteLine(text);
				string[] arr = text.Split (new string[] { ";" }, StringSplitOptions.None);
				Floor = float.Parse (arr [3]);
				TilePosition = new Vector3 (float.Parse (arr [1]) * 0.32F, (Floor -7) * 3, float.Parse (arr [2]) * 0.32F);
			
				GameObject SpriteGameObject = new GameObject ();
				SpriteGameObject.transform.parent = TerrainTileMap.transform;
				SpriteGameObject.transform.Rotate (-90F, 0F, 0F);
				SpriteGameObject.transform.name = arr [0];
			
				SpriteGameObject.transform.position = TilePosition;

				if( (Convert.ToInt32(arr[0]) > 4620 && Convert.ToInt32(arr[0]) < 4633) || (Convert.ToInt32(arr[0]) > 486 && Convert.ToInt32(arr[0]) < 499) || (Convert.ToInt32(arr[0]) > 362 && Convert.ToInt32(arr[0]) < 381)){
					SpriteGameObject.AddComponent <NavMeshObstacle> ();
					SpriteGameObject.GetComponent<NavMeshObstacle> ().size = new Vector3(0.32F, 0.32F, 0.01F);
				}

				SpriteGameObject.AddComponent <SpriteRenderer> ();			
				SpriteGameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("sprites/" + arr [0], typeof(Sprite)) as Sprite;
				SpriteGameObject.transform.tag = "Tile";
				CurrLine = CurrLine + 1;
			} 

			#if UNITY_EDITOR
			PrefabUtility.ReplacePrefab(TerrainTileMap, emptyObj, ReplacePrefabOptions.ConnectToPrefab);	

			DestroyImmediate(TerrainTileMap);
			TerrainTileMap = null;
			Resources.UnloadUnusedAssets();
			System.GC.Collect();
			#endif
			CountPF = CountPF+1;
			lastInterval = timeNow;
			Liberado = false;
		}
	}
}