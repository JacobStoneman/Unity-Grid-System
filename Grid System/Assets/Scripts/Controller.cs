using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    RectangleMapManager RectangleMap;
    HexagonMapManager HexagonMap;

    void Awake()
    {
		RectangleMap = new RectangleMapManager(GridLayout.CellSwizzle.XYZ, new Vector3(1, 1, 1));
		RectangleMap.CreateMapFromJson("pathMap", "CheckerBoard/CheckerBoard");

		HexagonMap = new HexagonMapManager(GridLayout.CellSwizzle.YZX, new Vector3(2,2,2));
        HexagonMap.CreateMapFromJson("hexMap","HexBoard/HexBoard");

		//RectangleMap.SetTileAtPos(new Vector3Int(-20, 0, 0), null);
		//RectangleMap.SetTileAtPos(new Vector3Int(-10, 0, 0), null);
		//RectangleMap.SaveMap("CheckerBoard/CheckerBoard");
	}

	private void Start()
	{
		//StartCoroutine(SetRandomOnTimer(0.005f, RectangleMap, RectangleMap.GetMapSize()));
		StartCoroutine(SetRandomOnTimer(0.005f, HexagonMap, HexagonMap.GetMapSize()));
	}

	IEnumerator SetRandomOnTimer(float duration, MapManager manager, Vector3Int size)
	{
		while (true)
		{
			manager.SetRandomTileAtPos(new Vector3Int(Random.Range(0, size.x), Random.Range(0, size.y), 0));
			yield return new WaitForSeconds(duration);
		}
	}

	private void Update()
	{
		
	}
}
