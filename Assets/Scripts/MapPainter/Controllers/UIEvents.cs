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
    
    public event Action OnLoadAssets;
    public void LoadAssets() => OnLoadAssets?.Invoke();

    public event Action<int> OnTileClicked;
    public void TileClicked(int tileNum) => OnTileClicked?.Invoke(tileNum);
}
