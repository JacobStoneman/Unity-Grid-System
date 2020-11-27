using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    RectangleMapManager RectangleMap;
    HexagonMapManager HexagonMap;

	public GameObject marker;

    void Awake()
    {
		//RectangleMap = new RectangleMapManager(GridLayout.CellSwizzle.YXZ, new Vector3Int(1, 1, 1));
		//RectangleMap.CreateMapFromJson("pathMap", "CheckerBoard/CheckerBoard");

		HexagonMap = new HexagonMapManager(GridLayout.CellSwizzle.XYZ, new Vector3Int(1, 1, 1));
		HexagonMap.CreateMapFromJson("hexMap", "HexBoard/HexBoard");
	}

	private void Start()
	{
		//StartCoroutine(SetRandomOnTimer(0.005f, RectangleMap, RectangleMap.GetMapSize()));
		//StartCoroutine(SetRandomOnTimer(0.005f, HexagonMap, HexagonMap.GetMapSize()));
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
		print( HexagonMap.GetTile(HexagonMap.GridPosFromMouse(Camera.main)));
		marker.transform.position = HexagonMap.GetSelectorPosition(Camera.main);
	}
}
