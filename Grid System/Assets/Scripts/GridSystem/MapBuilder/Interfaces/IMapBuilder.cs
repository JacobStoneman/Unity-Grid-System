using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.GridLayout;

public interface IMapBuilder
{
	Dictionary<string, Tile> CreateNewMap(string assets, string mapName, Grid parent);
	void CreateTestMap(string path, Grid parent);
	void CreateMapFromJson(string mapName, string path, Grid parent);
	Dictionary<string,Tile> GetTileAssets();
	Vector3Int GetMapSize();
	void SetTileAtPos(Vector3Int gridPos, string asset);
	void SetRandomTileAtPos(Vector3Int gridPos);
	TileBase GetTile(Vector3Int gridPos);
	TileBase GetTile(Vector3Int gridPos, out string asset);
	TileBase[] GetAllTiles();
	void SetScale(Vector3 scale);
	void SetSwizzle(CellSwizzle swizzle);
	void SetAnchor(Vector3 anchor);
	void WriteMapData(string path);
}
