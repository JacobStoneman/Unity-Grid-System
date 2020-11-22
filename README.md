# Unity Grid System
## Walkthrough
### Loading prebuilt grid
- json file should exist in Resource folder
```json
{
  "Path": "CheckerBoard/Tiles",
  "xLength": 8,
  "Data": [ 1, 2, 1, 2, ...]
}
```
- Path refers to directory containing tiles to use (in Resources folder)
- xLength determines the length of the grid before beginning on next row above
- Data determines the placement of tiles - each number is a tile based on its position in the directory, any other numbers will be empty grid spaces

- Construct a new map object and call the CreateMapFromPath method passing in the name and path
```cs
    MapManager Map;
    void Awake()
    {
        Map = new MapManager(GridLayout.CellLayout.Rectangle, GridLayout.CellSwizzle.XYZ);
        Map.CreateMapFromPath("pathMap", "CheckerBoard/CheckerBoard");
    }
```




## TODO

- -

## Notes

- All GameObjects that exist on the map should implement an IMove interface which controls their movement between grid cells
- CompressMap should be a private method called only when custom map building is involved

## Links
[Tilemaps through code](https://medium.com/@pudding_entertainment/unity-how-to-create-2d-tilemap-programmatically-afb1f94ffce5)

[Loading assets from path](https://docs.unity3d.com/ScriptReference/AssetDatabase.LoadAssetAtPath.html)

