using System;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    public static UIEvents current;

    void Awake()
    {
        current = this;
    }

    public event Action OnNewMapClicked;
    public void NewMapClicked() => OnNewMapClicked?.Invoke();

    public event Action<int> OnTileClicked;
    public void TileClicked(int tileNum) => OnTileClicked?.Invoke(tileNum);
}
