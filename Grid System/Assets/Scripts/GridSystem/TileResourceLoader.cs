using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileResourceLoader
{
	private string _path;

	public Dictionary<string,Tile> TileAssets { get; private set; }

	public TileResourceLoader(string path)
	{
		_path = path;
		LoadAllTiles();
	}

	private void LoadAllTiles()
	{
		object[] loaded = Resources.LoadAll(_path, typeof(Tile));

		TileAssets = new Dictionary<string, Tile>();
		foreach(Object obj in loaded)
		{
			TileAssets.Add(obj.name,(Tile)obj);
		}
	}
}
