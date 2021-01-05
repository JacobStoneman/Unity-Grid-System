using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UIEvents : MonoBehaviour
{
    public static UIEvents current;

    void Awake()
    {
        current = this;
    }

    public event Action<string,string> OnNewMapClicked;
    public void NewMapClicked(string path, string name) => OnNewMapClicked?.Invoke(path,name);

    public event Action<string, string> OnSaveClicked;
    public void SaveClicked(string fileName, string path) => OnSaveClicked?.Invoke(fileName, path);
    
    public event Action OnLoadAssets;
    public void LoadAssets() => OnLoadAssets?.Invoke();

    public event Action<Tile> OnNewTileSet;
    public void NewTileSet(Tile tile) => OnNewTileSet?.Invoke(tile);

    public event Action<GameObject> OnTileAssetClicked;
    public void TileClicked(GameObject asset) => OnTileAssetClicked?.Invoke(asset);

    public event Action<int> OnMapTypeSet;
    public void MapTypeSet(int value) => OnMapTypeSet?.Invoke(value);

    public event Action<string> OnLoadClicked;
    public void LoadClicked(string path) => OnLoadClicked?.Invoke(path);
}
