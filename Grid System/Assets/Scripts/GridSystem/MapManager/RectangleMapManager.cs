using System.Collections;
using System.Collections.Generic;
using static UnityEngine.GridLayout;

public class RectangleMapManager : MapManager
{
	private new IRectangleMapBuilder _mapBuilder;
	public RectangleMapManager() : base(CellLayout.Rectangle)
	{
		_mapBuilder = new RectangleMapBuilder(CellSwizzle.XYZ);
		base._mapBuilder = _mapBuilder;
	}

	public RectangleMapManager(CellSwizzle swizzle) : base(CellLayout.Rectangle,swizzle)
	{
		_mapBuilder = new RectangleMapBuilder(swizzle);
		base._mapBuilder = _mapBuilder;
	}

	//public void CreateMapFromJson(string mapName, string path) => _mapBuilder.CreateMapFromJson(mapName, path, _baseGrid);
}
