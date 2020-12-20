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

    public event Action OnNewMapClicked;
    public void NewMapClicked() => OnNewMapClicked?.Invoke();
    
    public event Action OnLoadAssetsClicked;
    public void LoadAssetsClicked() => OnLoadAssetsClicked?.Invoke();

    public event Action<int> OnTileClicked;
    public void TileClicked(int tileNum) => OnTileClicked?.Invoke(tileNum);

    public event Action<Dictionary<string, Tile>> OnLoadTileAssets;
    public void LoadTileAssets(Dictionary<string, Tile> tileAssets) => OnLoadTileAssets?.Invoke(tileAssets);
}
