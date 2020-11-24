using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.GridLayout;

public abstract class MapManager
{
	protected Grid _baseGrid;
	
	protected IMapBuilder _mapBuilder;

	public List<Tile> TileTypes { get;set; }
	public List<MapTile> AllTiles { get; private set; }

	public MapManager(CellLayout layout)
	{
		_baseGrid = new GameObject("Grid").AddComponent<Grid>();
		Layout = layout;
		Swizzle = CellSwizzle.XYZ;
		CellSize = new Vector3(1, 1, 1);
	}

	public MapManager(CellLayout layout, CellSwizzle swizzle, Vector3 cellSize)
	{
		_baseGrid = new GameObject("Grid").AddComponent<Grid>();
		Layout = layout;
		Swizzle = swizzle;
		CellSize = cellSize;
	}

	//TODO: To properly implement this, setOrientation needs to be replaced with a customOrientation method
	public Vector3 CellSize
	{
		get { return CellSize; }
		private set { _baseGrid.cellSize = value; }
	}

	public CellLayout Layout
	{
		get { return Layout; }
		private set { _baseGrid.cellLayout = value; }
	}
	public CellSwizzle Swizzle
	{
		get { return Swizzle; }
		private set { _baseGrid.cellSwizzle = value; }
	}

	//TODO: This will not work with different cell swizzles
	public Vector3Int GetGridPosFromMousePos()
	{
		Vector3Int gridCoord =_baseGrid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		return new Vector3Int(gridCoord.x, gridCoord.y, 0);
	}
	public Vector3Int GetGridPosFromLocalCoords(Vector3 coords) => _baseGrid.LocalToCell(coords);
	public Vector3Int GetGridPosFromWorldCoords(Vector3 coords) => _baseGrid.WorldToCell(coords);
	public Dictionary<string,Tile> GetTileAssets() => _mapBuilder.GetTileAssets();
	public void CreateTestMap(string path) => _mapBuilder.CreateTestMap(path,_baseGrid);
	public void CreateMapFromJson(string mapName, string path) => _mapBuilder.CreateMapFromJson(mapName, path, _baseGrid);
	public Vector3Int GetMapSize() => _mapBuilder.GetMapSize();
	public TileBase GetTile(Vector3Int gridPos) => _mapBuilder.GetTile(gridPos);
	public TileBase GetTile(Vector3Int gridPos, out string asset) => _mapBuilder.GetTile(gridPos, out asset);
	public void SetTileAtPos(Vector3Int gridPos, string asset) => _mapBuilder.SetTileAtPos(gridPos, asset);
	public void SetRandomTileAtPos(Vector3Int gridPos) => _mapBuilder.SetRandomTileAtPos(gridPos);
}
