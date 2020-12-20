# Unity Grid System
## What Is It?
Dynamic Maps is an easy to use tool I created which builds on Unity's existing Tilemap implementation allowing for much easier, dynamic control through code. Using this tool Tilemaps can be easily saved, loaded, and modified during run time.

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
    RectangleMapManager Map;
    void Awake()
    {
        Map = new RectangleMapManager(GridLayout.CellSwizzle.XYZ);
        Map.CreateMapFromJson("pathMap", "CheckerBoard/CheckerBoard");
    }
```
## DOD
- [ ] Class library that can be added to any project and allows for dynamic map creation
- [ ] Basic Hex and rectangle maps implemented
- [ ] An easy to understand file structure
- [ ] A skeleton map editor that can be built upon in different projects
- [ ] A clear README that explains what the project does and how to use it

## Necessary UI
- New hex map
- New rectangle map
- Save map to json (Move all json to a MapSaves folder)
- Load from json
- Tile Selection

## TODO
(After UI stuff)
- Clean up code and file structure
- Last minute changes
- README
- Upload finished project
- Add to portfolio
- Mapbuilder needs to be abstract

## Notes

- All GameObjects that exist on the map should implement an IMove interface which controls their movement between grid cells
- CompressMap should be a private method called only when custom map building is involved
- Look at using default parameters in the constructors

## Links
[Tilemaps through code](https://medium.com/@pudding_entertainment/unity-how-to-create-2d-tilemap-programmatically-afb1f94ffce5)

[Loading assets from path](https://docs.unity3d.com/ScriptReference/AssetDatabase.LoadAssetAtPath.html)

[3D Camera position](https://docs.unity3d.com/ScriptReference/Camera.ScreenToWorldPoint.html)

[Loading resources alternative](https://docs.unity3d.com/Manual/StreamingAssets.html)

