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
		MapData data = ReadMapData(path);
		CreateEmptyMap(mapName, parent);

		int yIndex = 0;
		for (int i = 0; i < data.Data.Length; i++)
		{
			if (i != 0 && i % data.xLength == 0)
			{
				yIndex++;
			}
			if (_loader.TileAssets.ContainsKey(data.Data[i]))
			{
				Map.SetTile(new Vector3Int(i - (yIndex * data.xLength), yIndex, 0), _loader.TileAssets[data.Data[i]]);
			}
		}
	}
}