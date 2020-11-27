using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridLayout;

public class HexagonMapManager : MapManager
{
	private new IHexagonMapBuilder _mapBuilder;

	public HexagonMapManager() : base(CellLayout.Hexagon)
	{
		_mapBuilder = new HexagonMapBuilder(new Vector3(1,1,1), CellSwizzle.XYZ);
		base._mapBuilder = _mapBuilder;
	}

	public HexagonMapManager(CellSwizzle swizzle, Vector3Int cellSize) : base(CellLayout.Hexagon,swizzle, cellSize)
	{
		_mapBuilder = new HexagonMapBuilder(cellSize, swizzle);
		base._mapBuilder = _mapBuilder;
	}
}
