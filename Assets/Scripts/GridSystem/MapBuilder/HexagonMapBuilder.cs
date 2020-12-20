using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridLayout;

public class HexagonMapBuilder : MapBuilder, IHexagonMapBuilder
{
	public HexagonMapBuilder(Vector3 cellSize, CellSwizzle swizzle) :base(cellSize, swizzle)
	{
		Anchor = new Vector3(0, 0, 0);
	}
}