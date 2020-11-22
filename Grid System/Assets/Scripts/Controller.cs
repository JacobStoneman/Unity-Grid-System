using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    MapManager Map;
    void Awake()
    {
        Map = new MapManager("Assets/Tiles/TileObjects", GridLayout.CellLayout.Rectangle, GridLayout.CellSwizzle.XYZ);
        Map.CreateMapFromPath("pathMap", "TestLevel");
    }

	private void Update()
	{
        print(Map.GetGridPosFromMousePos());
	}
}
