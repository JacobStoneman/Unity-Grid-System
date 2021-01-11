# Unity Grid System
An API that builds on Unity's existing Tilemap implementation to provide more options for dynamic control during run time. Included in this project is the grid API implementation and an editor that uses this API to allow for custom maps to be created from some base tile sets. 

### Tilemaps are saved in JSON format
```json
{
{"Path":"checkerboard",
"OriginX":0,
"OriginY":0,
"OriginZ":0,
"xLength":8,
"Data":["White","Black","White","Black","White","Black","White" ...
}
```
- Path refers to directory containing tiles to use (in Resources folder)
- Origin attributes refer to the start point for tiles to be placed from
- xLength determines the length of the grid before beginning on next row above
- Data determines the tile placed at each position
- Construct a new map object and call the CreateMapFromPath method passing in the name and path
```cs
    RectangleMapManager Map;
    void Awake()
    {
        Map = new RectangleMapManager(GridLayout.CellSwizzle.XYZ);
        Map.CreateMapFromJson("Checkerboard", "CheckerBoardData");
    }
```

### Map Editor
[Editor](Screenshots/HexMap.png)