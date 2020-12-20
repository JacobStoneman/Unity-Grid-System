using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapPainterController : MonoBehaviour
{
    public GameObject highlight;
    public StringVariable CoordText;
    public BoolVariable UIInteraction;
    public BoolVariable MouseOnScreen;

    HexagonMapManager hexMap;
    string selectedTile;

    // Start is called before the first frame update
    void Start()
    {
        UIEvents.current.OnTileClicked += TileSelected;
        UIEvents.current.OnNewMapClicked += NewMap;

        NewMap("Hexboard/Tiles", "New Map");
    }

    // Update is called once per frame
    void Update()
    {
        if (!UIInteraction.value && MouseOnScreen.value)
        {
            highlight.gameObject.SetActive(true);
            highlight.transform.position = hexMap.GetSelectorPosition(Camera.main);
            CheckMouse();
        } else
		{
            highlight.gameObject.SetActive(false);
		}
    }

    void CheckMouse()
    {
        Vector3Int mousePos = hexMap.GridPosFromMouse(Camera.main);
        if (Input.GetMouseButton(0))
        {
            hexMap.SetTileAtPos(hexMap.GridPosFromMouse(Camera.main), "Tile1");
        } 
        else if (Input.GetMouseButton(1))
		{
            hexMap.SetTileAtPos(hexMap.GridPosFromMouse(Camera.main), null);
        }
        CoordText.value = $"{mousePos.x},{mousePos.y}";
    }

    void NewMap(string path, string name)
	{
        hexMap = new HexagonMapManager();
        hexMap.CreateNewMap(path, name);
        selectedTile = hexMap.GetTileAssets().Keys.ToArray()[0];
        hexMap.SetTileAtPos(new Vector3Int(0, 0, 0), selectedTile);
        UIEvents.current.LoadAssets();
    }

    public Dictionary<string, Tile> GetTileAssets() => hexMap.GetTileAssets();

    void TileSelected(int tileNum)
	{
	}

	private void OnDestroy()
	{
        UIEvents.current.OnTileClicked -= TileSelected;
        UIEvents.current.OnNewMapClicked -= NewMap;
    }
}