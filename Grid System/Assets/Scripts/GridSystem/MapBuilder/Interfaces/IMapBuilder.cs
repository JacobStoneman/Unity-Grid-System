using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;

public interface IMapBuilder
{
	void CreateTestMap(string path, Grid parent);
	void CreateMapFromJson(string mapName, string path, Grid parent);
	Dictionary<string,Tile> GetTileAssets();
	Vector3Int GetMapSize();
}
