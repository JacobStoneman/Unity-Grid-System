﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.GridLayout;

public class MapConstructor
{
	private Grid _baseGrid;
	private Tilemap _map;

	public List<Tile> TileTypes { get;set; }
	public List<MapTile> AllTiles { get; private set; }

	public MapConstructor()
	{
		_baseGrid = new GameObject("Grid").AddComponent<Grid>();
		CellSize = new Vector3(1,1,1);
		Layout = CellLayout.Rectangle;
		Swizzle = CellSwizzle.XYZ;
	}

	public MapConstructor(Vector3 cellSize, CellLayout layout, CellSwizzle swizzle)
	{
		_baseGrid = new GameObject("Grid").AddComponent<Grid>();
		CellSize = cellSize;
		Layout = layout;
		Swizzle = swizzle;
	}

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

	public Vector3Int GetGridPosFromLocalCoords(Vector3 coords) => _baseGrid.LocalToCell(coords);
	public Vector3Int GetGridPosFromWorldCoords(Vector3 coords) => _baseGrid.WorldToCell(coords);

	//TODO: This will not work with different cell swizzles
	public Vector3Int GetGridPosFromMousePos()
	{
		Vector3Int gridCoord =_baseGrid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		return new Vector3Int(gridCoord.x, gridCoord.y, 0);
	}

	public void CreateEmptyMap(string mapName)
	{
		_map = new GameObject(mapName).AddComponent<Tilemap>();
		_map.gameObject.AddComponent<TilemapRenderer>();
		_map.gameObject.transform.SetParent(_baseGrid.gameObject.transform);
	}

	private void CompressMap()
	{
		_map.origin = new Vector3Int(0, 0, 0);
		_map.CompressBounds();
	}

	public void CreateTestMap(TileResourceLoader loader)
	{
		CreateEmptyMap("TestMap");

	}
}
