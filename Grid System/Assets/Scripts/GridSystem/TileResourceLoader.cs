using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileResourceLoader
{
	private string _path;

	public List<Tile> TileAssets { get; private set; }

	public TileResourceLoader(string path)
	{
		_path = path;
		LoadAllTiles();
	}

	private void LoadAllTiles()
	{
		object[] loaded = Resources.LoadAll(_path, typeof(Tile));

		TileAssets = new List<Tile>();
		foreach(Object obj in loaded)
		{
			TileAssets.Add((Tile)obj);
		}
	}


}
