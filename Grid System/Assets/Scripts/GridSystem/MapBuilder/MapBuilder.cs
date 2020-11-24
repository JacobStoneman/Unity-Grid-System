using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.GridLayout;
using System.Linq;

public abstract class MapBuilder : IMapBuilder
{
	protected TileResourceLoader _loader;
	public Tilemap Map { get; private set; }

	public MapTransformControl MapTransform;

	System.Random rand = new System.Random();

	//TODO: Needs some way of setting up anchor
	public MapBuilder(Vector3 cellSize,CellSwizzle swizzle)
	{
		MapTransform = new MapTransformControl(cellSize, swizzle);
		Anchor = new Vector3(0.5f, 0.5f);
	}

	public Vector3 Anchor { get; set; }

	private void SetOrientation()
	{
		Map.orientation = Tilemap.Orientation.Custom;
		Map.orientationMatrix = MapTransform.GetOrientation();
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
	}

	public virtual void CreateMapFromJson(string mapName, string path, Grid parent)
	{
		MapData data = ReadMapData(path);
		CreateEmptyMap(mapName, parent);

		int yIndex = 0;
		for (int i = 0; i < data.Data.Length; i++)
		{
			if (i != 0 && i % data.xLength == 0)
			{
				yIndex++;
			}
			if (_loader.TileAssets.ContainsKey(data.Data[i]))
			{
				Map.SetTile(new Vector3Int(i - (yIndex * data.xLength), yIndex, 0), _loader.TileAssets[data.Data[i]]);
			}
		}
	}

	public Vector3Int GetMapSize() => Map.size;
	//TODO: This may need to be a Tile return type
	public TileBase GetTile(Vector3Int gridPos) => Map.GetTile(gridPos);
	public TileBase GetTile(Vector3Int gridPos, out string asset)
	{
		TileBase result = Map.GetTile(gridPos);
		asset = result.name;
		return result;
	}
	public Dictionary<string,Tile> GetTileAssets() => _loader.TileAssets;
	public void SetTileAtPos(Vector3Int gridPos, string asset) => Map.SetTile(gridPos, _loader.TileAssets[asset]);
	public void SetRandomTileAtPos(Vector3Int gridPos) => Map.SetTile(gridPos, _loader.TileAssets.ElementAt(rand.Next(0, _loader.TileAssets.Count)).Value);
}