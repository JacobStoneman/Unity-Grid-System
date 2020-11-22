using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.GridLayout;

//TODO: This should abstract to enforce child class is used
public abstract class MapBuilder : IMapBuilder
{
	protected TileResourceLoader _loader;
	public Tilemap Map { get; private set; }
	private CellSwizzle _swizzle;

	//TODO: Needs some way of setting up anchor
	public MapBuilder(CellSwizzle swizzle)
	{
		_swizzle = swizzle;
		Anchor = new Vector3(0.5f, 0.5f);
	}

	public Vector3 Anchor { get; set; }

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
	protected MapData ReadMapData(string path)
	{
		TextAsset jsonFile = (TextAsset)Resources.Load(path, typeof(TextAsset));
		MapData loadedData = JsonUtility.FromJson<MapData>(jsonFile.text);
		_loader = new TileResourceLoader(loadedData.Path);
		return loadedData;
	}

	//TODO: These should be fine for all Map types
	protected void CreateEmptyMap(string mapName, Grid parent)
	{
		Map = new GameObject(mapName).AddComponent<Tilemap>();
		SetOrientation();
		Map.tileAnchor = Anchor;
		Map.gameObject.AddComponent<TilemapRenderer>();
		Map.gameObject.transform.SetParent(parent.gameObject.transform);
	}
	public void CreateTestMap(string path, Grid parent)
	{
		ReadMapData(path);
		CreateEmptyMap("TestMap", parent);

		int count = _loader.TileAssets.Count;

		for (int i = 0; i < count; i++)
		{
			Map.SetTile(new Vector3Int(i, 0, 0), _loader.TileAssets[i]);
		}
	}

	public abstract void CreateMapFromJson(string mapName, string path, Grid parent);
}