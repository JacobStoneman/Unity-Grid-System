using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    MapConstructor Map;
    void Start()
    {
        Map = new MapConstructor(new Vector3(10,10,10), GridLayout.CellLayout.Rectangle, GridLayout.CellSwizzle.XYZ);
        Map.CreateEmptyMap("Test Map");

        TileResourceLoader loader = new TileResourceLoader("Assets/Tiles/TileObjects");
    }

    void Update()
    {

    }
}
