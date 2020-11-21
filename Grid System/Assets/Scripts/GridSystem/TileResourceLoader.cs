using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine.Tilemaps;

public class TileResourceLoader
{
	private string _path;
	private string[] _allFiles;

	public List<Tile> TileAssets { get; private set; }

	public TileResourceLoader(string path)
	{
		_path = path;
		FindAllFiles();
		LoadTileAssets();
	}

	private void FindAllFiles()
	{
		string[] temp = Directory.GetFiles(_path);
		List<string> newList = new List<string>();

		foreach(string str in temp)
		{
			if (!str.Contains(".meta"))
			{
				//TODO: This may be necessary if issues come from reading tiles
				//string newString = str.Replace(Path.DirectorySeparatorChar, '/'); 
				newList.Add(str);
			}
		}

		_allFiles = newList.ToArray();
	}

	private void LoadTileAssets()
	{
		TileAssets = new List<Tile>();
		foreach(string str in _allFiles)
		{
			Tile newTile = (Tile)AssetDatabase.LoadAssetAtPath(str, typeof(Tile));
			TileAssets.Add(newTile);
		}
	}
}
