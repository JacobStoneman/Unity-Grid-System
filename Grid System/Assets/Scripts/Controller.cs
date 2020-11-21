using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    MapConstructor Map;
    void Start()
    {
        Map = new MapConstructor(GridLayout.CellLayout.Rectangle, GridLayout.CellSwizzle.XYZ);
        Map.CreateTestMap(new TileResourceLoader("Assets/Tiles/TileObjects"));

        //TileResourceLoader loader = new TileResourceLoader("Assets/Tiles/TileObjects");
    }

    void Update()
    {

    }
}
