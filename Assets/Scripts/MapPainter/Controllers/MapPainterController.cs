using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
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
        UIEvents.current.OnNewTileSet += TileSelected;
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
            GridInteract();
        } else
		{
            highlight.gameObject.SetActive(false);
		}
    }

    void GridInteract()
    {
        if (selectedTile != null)
        {
            if (Input.GetMouseButton(0))
            {
                hexMap.SetTileAtPos(hexMap.GridPosFromMouse(Camera.main), selectedTile);
            }
            else if (Input.GetMouseButton(1))
            {
                hexMap.SetTileAtPos(hexMap.GridPosFromMouse(Camera.main), null);
            }
        }
        Vector3Int mousePos = hexMap.GridPosFromMouse(Camera.main);
        CoordText.value = $"{mousePos.x},{mousePos.y}";
    }

    void NewMap(string path, string name)
	{
        if (hexMap != null && hexMap.MapExists()) hexMap.ClearMap();
        selectedTile = null;

        hexMap = new HexagonMapManager();
        hexMap.CreateNewMap(path, name);
        if (hexMap.GetTileAssets() != null && hexMap.GetTileAssets().Count > 0)
        {
            selectedTile = hexMap.GetTileAssets().Keys.ToArray()[0];
            hexMap.SetTileAtPos(new Vector3Int(0, 0, 0), selectedTile);
        }
        UIEvents.current.LoadAssets();
    }

    public Dictionary<string, Tile> GetTileAssets() => hexMap.GetTileAssets();

    void TileSelected(Tile tile)
	{
        selectedTile = tile.name;
	}

	private void OnDestroy()
	{
        UIEvents.current.OnNewTileSet -= TileSelected;
        UIEvents.current.OnNewMapClicked -= NewMap;
    }
}