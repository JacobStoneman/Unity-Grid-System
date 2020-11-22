using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    MapManager Map;
    void Awake()
    {
        Map = new MapManager(GridLayout.CellLayout.Rectangle, GridLayout.CellSwizzle.XYZ);
        Map.CreateMapFromPath("pathMap", "CheckerBoard/CheckerBoard");
    }

	private void Update()
	{

	}
}
