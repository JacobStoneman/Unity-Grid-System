using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapBuilder
{
	private TileResourceLoader _loader;
	public Tilemap Map { get; private set; }

	public MapBuilder(TileResourceLoader loader)
	{
		_loader = loader;
	}

	private void CompressMap()
	{
		Map.origin = new Vector3Int(0, 0, 0);
		Map.CompressBounds();
	}

	public void CreateEmptyMap(string mapName, Grid parent)
	{
		Map = new GameObject(mapName).AddComponent<Tilemap>();
		Map.gameObject.AddComponent<TilemapRenderer>();
		Map.gameObject.transform.SetParent(parent.gameObject.transform);
	}

	public void CreateTestMap(Grid parent)
	{
		CreateEmptyMap("TestMap", parent);

		int count = _loader.TileAssets.Count;

		for (int i = 0; i < count; i++)
		{
			Map.SetTile(new Vector3Int(i, 0, 0), _loader.TileAssets[i]);
		}
	}

	private MapData ReadMapData(string path)
	{
		TextAsset jsonFile = (TextAsset)Resources.Load(path, typeof(TextAsset));

		MapData loadedData = JsonUtility.FromJson<MapData>(jsonFile.text);

		return loadedData;
	}

	public void CreateMapFromPath(string mapName, string path, Grid parent)
	{
		MapData data = ReadMapData(path);
		CreateEmptyMap(mapName, parent);

		for(int i = 0; i < data.Data.Length; i++)
		{
			if (data.Data[i] != 0)
			{
				Map.SetTile(new Vector3Int(i, 0, 0), _loader.TileAssets[data.Data[i]-1]);
			}
		}
	}
}

[Serializable]
public class MapData
{
	public int xLength;
	public int[] Data;
}