using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.GridLayout;

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

	protected void CreateEmptyMap(string mapName, Grid parent)
	{
		Map = new GameObject(mapName).AddComponent<Tilemap>();
		SetOrientation();
		Map.tileAnchor = Anchor;
		Map.gameObject.AddComponent<TilemapRenderer>();
		Map.gameObject.transform.SetParent(parent.gameObject.transform);
	}

	/// <summary>
	/// Generates one of each tile read in from the given path
	/// </summary>
	/// <param name="path"> The path to the json file relative to the Resource folder</param>
	/// <param name="parent"> The underlying grid the tilemap object is a child of</param>
	public void CreateTestMap(string path, Grid parent)
	{
		ReadMapData(path);
		CreateEmptyMap("TestMap", parent);

		int index = 0;
		foreach(KeyValuePair<string, Tile> tile in _loader.TileAssets)
		{
			Map.SetTile(new Vector3Int(index, 0, 0), tile.Value);
			index++;
		}

		//int count = _loader.TileAssets.Count;

		//for (int i = 0; i < count; i++)
		//{
		//	Map.SetTile(new Vector3Int(i, 0, 0), _loader.TileAssets[i]);
		//}
	}

	public abstract void CreateMapFromJson(string mapName, string path, Grid parent);
	public Vector3Int GetMapSize() => Map.size;
	public Dictionary<string,Tile> GetTileAssets() => _loader.TileAssets;
}