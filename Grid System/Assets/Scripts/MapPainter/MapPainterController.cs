using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPainterController : MonoBehaviour
{
    public GameObject highlight;

    HexagonMapManager hexMap;

    // Start is called before the first frame update
    void Start()
    {
        hexMap = new HexagonMapManager();
        hexMap.CreateNewMap("HexBoard/Tiles", "NewMap");
        hexMap.SetTileAtPos(new Vector3Int(0, 0, 0), "Tile1");

        
    }

    // Update is called once per frame
    void Update()
    {
        highlight.transform.position = hexMap.GetSelectorPosition(Camera.main);
        CheckMouse();
    }

    void CheckMouse()
    {
        if (Input.GetMouseButton(0))
        {
            hexMap.SetTileAtPos(hexMap.GridPosFromMouse(Camera.main), "Tile1");
        } 
        else if (Input.GetMouseButton(1))
		{
            hexMap.SetTileAtPos(hexMap.GridPosFromMouse(Camera.main), null);
        }
    }
}
