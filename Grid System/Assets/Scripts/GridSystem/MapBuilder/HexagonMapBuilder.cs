using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridLayout;

public class HexagonMapBuilder : MapBuilder, IHexagonMapBuilder
{
	public HexagonMapBuilder(CellSwizzle swizzle) :base(swizzle)
	{
		Anchor = new Vector3(0, 0, 0);
	}

	public override void CreateMapFromJson(string mapName, string path, Grid parent)
	{
		throw new System.NotImplementedException();
	}
}