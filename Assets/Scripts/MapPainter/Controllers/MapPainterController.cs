using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public enum MapType{
    HEX,
    RECTANGLE
}

public class MapPainterController : MonoBehaviour
{
    public GameObject highlight;
    public StringVariable CoordText;
    public BoolVariable UIInteraction;
    public BoolVariable MouseOnScreen;

    public MapType mType = MapType.HEX;
    MapManager newMap;
    string selectedTile;

    // Start is called before the first frame update
    void Start()
    {
        UIEvents.current.OnNewTileSet += TileSelected;
        UIEvents.current.OnNewMapClicked += NewMap;
        UIEvents.current.OnSaveClicked += Save;
        UIEvents.current.OnMapTypeSet += SetMapType;

        NewMap("Hexboard", "New Map");
    }

    // Update is called once per frame
    void Update()
    {

        if (!UIInteraction.value && MouseOnScreen.value)
        {
            highlight.gameObject.SetActive(true);
            highlight.transform.position = newMap.GetSelectorPosition(Camera.main);
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
                newMap.SetTileAtPos(newMap.GridPosFromMouse(Camera.main), selectedTile);
            }
            else if (Input.GetMouseButton(1))
            {
                newMap.SetTileAtPos(newMap.GridPosFromMouse(Camera.main), null);
            }
        }
        Vector3Int mousePos = newMap.GridPosFromMouse(Camera.main);
        CoordText.value = $"{mousePos.x},{mousePos.y}";
    }

    void NewMap(string path, string name)
	{
        if (newMap != null && newMap.MapExists()) newMap.ClearMap();
        selectedTile = null;

		switch (mType)
		{
            case MapType.HEX:
                newMap = new HexagonMapManager();
                break;
            case MapType.RECTANGLE:
                newMap = new RectangleMapManager();
                break;
            default:
                print("Error");
                break;
		}

        newMap.CreateNewMap(path, name);
        if (newMap.GetTileAssets() != null && newMap.GetTileAssets().Count > 0)
        {
            selectedTile = newMap.GetTileAssets().Keys.ToArray()[0];
            newMap.SetTileAtPos(new Vector3Int(0, 0, 0), selectedTile);
        }
        UIEvents.current.LoadAssets();
    }

    void SetMapType(int value) => mType = (MapType)value;

    public Dictionary<string, Tile> GetTileAssets() => newMap.GetTileAssets();

    void Save(string fileName, string path) => newMap.SaveMap(fileName, path);

    void TileSelected(Tile tile) => selectedTile = tile.name;

	private void OnDestroy()
	{
        UIEvents.current.OnNewTileSet -= TileSelected;
        UIEvents.current.OnNewMapClicked -= NewMap;
        UIEvents.current.OnSaveClicked -= Save;
        UIEvents.current.OnMapTypeSet -= SetMapType;
    }
}