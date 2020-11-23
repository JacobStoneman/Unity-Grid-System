using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Controller : MonoBehaviour
{
    RectangleMapManager RectangleMap;
    HexagonMapManager HexagonMap;
    void Awake()
    {
		RectangleMap = new RectangleMapManager(GridLayout.CellSwizzle.XYZ);
		RectangleMap.CreateMapFromJson("pathMap", "CheckerBoard/CheckerBoard");

		HexagonMap = new HexagonMapManager(GridLayout.CellSwizzle.YZX);
        HexagonMap.CreateMapFromJson("hexMap","HexBoard/HexBoard");

    }

	private void Update()
	{
        
	}
}
