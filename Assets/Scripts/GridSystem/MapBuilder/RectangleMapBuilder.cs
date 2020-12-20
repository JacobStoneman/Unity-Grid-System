using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridLayout;

public class RectangleMapBuilder : MapBuilder, IRectangleMapBuilder
{
	public RectangleMapBuilder(Vector3 cellSize, CellSwizzle swizzle) : base(cellSize, swizzle)
	{}
}
