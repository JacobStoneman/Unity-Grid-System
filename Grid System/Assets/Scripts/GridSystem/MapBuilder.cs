using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapBuilder
{
	public Tilemap Map { get; private set; }

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

	public void CreateTestMap(TileResourceLoader loader, Grid parent)
	{
		CreateEmptyMap("TestMap", parent);

		int count = loader.TileAssets.Count;

		for (int i = 0; i < count; i++)
		{
			Map.SetTile(new Vector3Int(i, 0, 0), loader.TileAssets[i]);
		}
	}
}
