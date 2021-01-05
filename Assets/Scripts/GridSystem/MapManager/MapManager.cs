using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.GridLayout;

public abstract class MapManager
{
	protected Grid _baseGrid;
	protected IMapBuilder _mapBuilder;


	public MapManager(CellLayout layout)
	{
		_baseGrid = new GameObject("Grid").AddComponent<Grid>();
		Layout = layout;
		Swizzle = CellSwizzle.XYZ;
		CellSize = new Vector3Int(1, 1, 1);
	}

	public MapManager(CellLayout layout, CellSwizzle swizzle, Vector3Int cellSize)
	{
		_baseGrid = new GameObject("Grid").AddComponent<Grid>();
		Layout = layout;
		Swizzle = swizzle;
		CellSize = cellSize;
	}

	//TODO: CellGap needs to be implemented

	private Vector3Int _cellSize;
	public Vector3Int CellSize
	{
		get { return _cellSize; }
		private set 
		{
			_cellSize = value;
			_baseGrid.cellSize = value; 
		}
	}

	private CellLayout _layout;
	public CellLayout Layout
	{
		get { return _layout; }
		private set 
		{
			_layout = value;
			_baseGrid.cellLayout = value; 
		}
	}

	private CellSwizzle _swizzle;
	public CellSwizzle Swizzle
	{
		get { return _swizzle; }
		private set 
		{
			_swizzle = value;
			_baseGrid.cellSwizzle = value; 
		}
	}

	/// <summary>
	/// Assumes the camera is orthograpic and looking directly at the grid
	/// </summary>
	/// <param name="cam"></param>
	/// <returns></returns>
	public Vector3Int GridPosFromMouse(Camera cam)
	{
		//TODO: This still needs a lot of testing for different swizzles
		Vector3Int result = new Vector3Int();
		if (cam.orthographic)
		{
			Vector3Int gridCoord =_baseGrid.WorldToCell(cam.ScreenToWorldPoint(Input.mousePosition));
			switch (Swizzle)
			{
				case CellSwizzle.XYZ:
					return new Vector3Int(gridCoord.x * CellSize.x, gridCoord.y * CellSize.y, 0);
				case CellSwizzle.XZY:
					return new Vector3Int(gridCoord.x * CellSize.x, 0, gridCoord.y * CellSize.y);
				case CellSwizzle.YXZ:
					return new Vector3Int(gridCoord.x * CellSize.x, gridCoord.y * CellSize.y, 0);
				case CellSwizzle.YZX:
					return new Vector3Int(gridCoord.x * CellSize.x, gridCoord.y * CellSize.y,0);
				case CellSwizzle.ZXY:
					return new Vector3Int(0,gridCoord.x * CellSize.x, gridCoord.y * CellSize.y);
				case CellSwizzle.ZYX:
					return new Vector3Int(0, gridCoord.y * CellSize.y, gridCoord.x * CellSize.x);
			}
		}

		return result;
	}

	public virtual Vector3 GetSelectorPosition(Camera cam)
	{
		return _baseGrid.CellToWorld(GridPosFromMouse(cam));
	}

	public Vector3Int GetGridPosFromLocalCoords(Vector3 coords) => _baseGrid.LocalToCell(coords);
	public Vector3Int GetGridPosFromWorldCoords(Vector3 coords) => _baseGrid.WorldToCell(coords);


	public Dictionary<string,Tile> GetTileAssets() => _mapBuilder.GetTileAssets();
	public TileBase GetTile(Vector3Int gridPos) => _mapBuilder.GetTile(gridPos);
	public TileBase GetTile(Vector3Int gridPos, out string asset) => _mapBuilder.GetTile(gridPos, out asset);
	public TileBase[] GetAllTiles() => _mapBuilder.GetAllTiles();
	public Vector3Int GetMapSize() => _mapBuilder.GetMapSize();


	public void SetTileAtPos(Vector3Int gridPos, string asset) => _mapBuilder.SetTileAtPos(gridPos, asset);
	public void SetRandomTileAtPos(Vector3Int gridPos) => _mapBuilder.SetRandomTileAtPos(gridPos);

	public void CreateNewMap(string assetPath, string mapName) => _mapBuilder.CreateNewMap(assetPath, mapName, _baseGrid);
	public void CreateTestMap(string path) => _mapBuilder.CreateTestMap(path,_baseGrid);
	public void CreateMapFromJson(string mapName, string path) => _mapBuilder.CreateMapFromJson(mapName, path, _baseGrid);


	/// <summary>
	/// These ensure the tiles scale and rotate properly to match the grid
	/// </summary>
	/// <param name="scale"></param>
	public void ScaleMap(Vector3Int scale)
	{
		CellSize = scale;
		_mapBuilder.SetScale(scale);
	}
	public void SwizzleMap(CellSwizzle swizzle)
	{
		Swizzle = swizzle;
		_mapBuilder.SetSwizzle(swizzle);
	}
	public void SetAnchor(Vector3 anchor) => _mapBuilder.SetAnchor(anchor);

	public void SaveMap(string fileName, string path) => _mapBuilder.WriteMapData(fileName, path);

	public bool MapExists() => _baseGrid != null;
	public void ClearMap() => Object.Destroy(_mapBuilder.GetParentGrid());
}
