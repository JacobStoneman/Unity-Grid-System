using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridLayout;

public class HexagonMapManager : MapManager
{
	private new IHexagonMapBuilder _mapBuilder;

	public HexagonMapManager() : base(CellLayout.Hexagon)
	{
		_mapBuilder = new HexagonMapBuilder(CellSwizzle.XYZ);
		base._mapBuilder = _mapBuilder;
	}

	public HexagonMapManager(CellSwizzle swizzle) : base(CellLayout.Hexagon,swizzle)
	{
		_mapBuilder = new HexagonMapBuilder(swizzle);
		base._mapBuilder = _mapBuilder;
	}
}
