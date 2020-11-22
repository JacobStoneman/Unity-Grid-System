﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.GridLayout;

public class MapManager
{
	public MapBuilder _mapBuilder;
	private Grid _baseGrid;

	public List<Tile> TileTypes { get;set; }
	public List<MapTile> AllTiles { get; private set; }

	public MapManager(string path)
	{
		_baseGrid = new GameObject("Grid").AddComponent<Grid>();
		//CellSize = new Vector3(1,1,1);
		Layout = CellLayout.Rectangle;
		Swizzle = CellSwizzle.XYZ;
		_mapBuilder = new MapBuilder(new TileResourceLoader(path));
	}

	public MapManager(string path, CellLayout layout, CellSwizzle swizzle)
	{
		_baseGrid = new GameObject("Grid").AddComponent<Grid>();
		//CellSize = cellSize;
		Layout = layout;
		Swizzle = swizzle;
		_mapBuilder = new MapBuilder(new TileResourceLoader(path));
	}

	//TODO: Reimplement when tile scaling issue is fixed
	//public Vector3 CellSize
	//{
	//	get { return CellSize; }
	//	private set { _baseGrid.cellSize = value; }
	//}

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

	public Vector3Int GetGridPosFromLocalCoords(Vector3 coords) => _baseGrid.LocalToCell(coords);
	public Vector3Int GetGridPosFromWorldCoords(Vector3 coords) => _baseGrid.WorldToCell(coords);

	//TODO: This will not work with different cell swizzles
	public Vector3Int GetGridPosFromMousePos()
	{
		Vector3Int gridCoord =_baseGrid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		return new Vector3Int(gridCoord.x, gridCoord.y, 0);
	}

	public void CreateTestMap() => _mapBuilder.CreateTestMap(_baseGrid);
	public void CreateMapFromPath(string mapName, string path) => _mapBuilder.CreateMapFromPath(mapName, path, _baseGrid);
}
