using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridLayout;

public class RectangleMapManager : MapManager
{
	private new IRectangleMapBuilder _mapBuilder;
	public RectangleMapManager() : base(CellLayout.Rectangle)
	{
		_mapBuilder = new RectangleMapBuilder(new Vector3(1,1,1), CellSwizzle.XYZ);
		base._mapBuilder = _mapBuilder;
	}

	public RectangleMapManager(CellSwizzle swizzle, Vector3Int cellSize) : base(CellLayout.Rectangle,swizzle,cellSize)
	{
		_mapBuilder = new RectangleMapBuilder(cellSize, swizzle);
		base._mapBuilder = _mapBuilder;
	}
}
