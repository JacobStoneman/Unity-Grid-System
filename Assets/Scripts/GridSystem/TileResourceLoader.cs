﻿using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileResourceLoader
{
	public string Path { get; private set; }

	public Dictionary<string,Tile> TileAssets { get; private set; }

	public TileResourceLoader(string path)
	{
		Path = path;
		LoadAllTiles();
	}

	private void LoadAllTiles()
	{
		if (Path.Length > 0)
		{
			object[] loaded = Resources.LoadAll(Path, typeof(Tile));
			TileAssets = new Dictionary<string, Tile>();
			foreach (Object obj in loaded)
			{
				TileAssets.Add(obj.name, (Tile)obj);
			}
		}
	}
}
