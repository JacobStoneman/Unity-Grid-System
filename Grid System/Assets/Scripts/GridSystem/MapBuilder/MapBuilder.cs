using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.GridLayout;

public class MapBuilder
{
	private TileResourceLoader _loader;
	public Tilemap Map { get; private set; }
	private CellSwizzle _swizzle;

	public MapBuilder(CellSwizzle swizzle)
	{
		_swizzle = swizzle;
	}

	private void SetOrientation()
	{
		switch (_swizzle)
		{
			case CellSwizzle.XYZ:
				Map.orientation = Tilemap.Orientation.XY;
				break;
			case CellSwizzle.XZY:
				Map.orientation = Tilemap.Orientation.XZ;
				break;
			case CellSwizzle.YXZ:
				Map.orientation = Tilemap.Orientation.YX;
				break;
			case CellSwizzle.YZX:
				Map.orientation = Tilemap.Orientation.ZX;
				break;
			case CellSwizzle.ZXY:
				Map.orientation = Tilemap.Orientation.ZY;
				break;
			case CellSwizzle.ZYX:
				Map.orientation = Tilemap.Orientation.ZY;
				break;
		}
	}

	private void CompressMap()
	{
		Map.origin = new Vector3Int(0, 0, 0);
		Map.CompressBounds();
	}

	/// <summary>
	/// Reads the json content from the passed in path found in the resources folder
	/// Constructs a new TileResourceLoader object that stores the information for each type of tile
	/// </summary>
	/// <param name="path"> The path to the json file relative to the Resource folder</param>
	/// <returns>The data for the map including the tile assets and data for each grid position</returns>
	private MapData ReadMapData(string path)
	{
		TextAsset jsonFile = (TextAsset)Resources.Load(path, typeof(TextAsset));
		MapData loadedData = JsonUtility.FromJson<MapData>(jsonFile.text);
		_loader = new TileResourceLoader(loadedData.Path);
		return loadedData;
	}

	private void CreateEmptyMap(string mapName, Grid parent)
	{
		Map = new GameObject(mapName).AddComponent<Tilemap>();
		SetOrientation();
		Map.gameObject.AddComponent<TilemapRenderer>();
		Map.gameObject.transform.SetParent(parent.gameObject.transform);
	}

	public void CreateTestMap(string path, Grid parent )
	{
		ReadMapData(path);
		CreateEmptyMap("TestMap", parent);

		int count = _loader.TileAssets.Count;

		for (int i = 0; i < count; i++)
		{
			Map.SetTile(new Vector3Int(i, 0, 0), _loader.TileAssets[i]);
		}
	}

	public void CreateMapFromPath(string mapName, string path, Grid parent)
	{
		MapData data = ReadMapData(path);
		CreateEmptyMap(mapName, parent);

		int yIndex = 0;
		for(int i = 0; i < data.Data.Length; i++)
		{
			if (i != 0 && i % data.xLength == 0)
			{
				yIndex++;
			}
			if (data.Data[i] != 0 && data.Data[i] <= _loader.TileAssets.Count)
			{
				Map.SetTile(new Vector3Int(i - (yIndex*data.xLength), yIndex, 0), _loader.TileAssets[data.Data[i]-1]);
			}
		}
	}
}

[Serializable]
public class MapData
{
	public string Path;
	public int xLength;
	public int[] Data;
}