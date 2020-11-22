using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridLayout;

public class RectangleMapBuilder : MapBuilder, IRectangleMapBuilder
{
	public RectangleMapBuilder(CellSwizzle swizzle) : base(swizzle)
	{}

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
			if (data.Data[i] != 0 && data.Data[i] <= _loader.TileAssets.Count)
			{
				Map.SetTile(new Vector3Int(i - (yIndex * data.xLength), yIndex, 0), _loader.TileAssets[data.Data[i] - 1]);
			}
		}
	}
}
