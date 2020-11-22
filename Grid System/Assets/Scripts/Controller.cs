using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    RectangleMapManager Map;
    HexagonMapManager Map2;
    void Awake()
    {
        Map = new RectangleMapManager(GridLayout.CellSwizzle.XYZ);
        Map.CreateMapFromJson("pathMap", "CheckerBoard/CheckerBoard");

        Map2 = new HexagonMapManager(GridLayout.CellSwizzle.XYZ);
        Map2.CreateTestMap("HexBoard/HexBoard");
    }

	private void Update()
	{

	}
}
