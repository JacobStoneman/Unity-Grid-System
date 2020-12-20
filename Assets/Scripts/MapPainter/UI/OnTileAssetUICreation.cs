using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class OnTileAssetUICreation : MonoBehaviour
{
	[SerializeField] Image image;
	[SerializeField] Text text;
	public void CreateAsset(string name, Tile tile)
	{
		text.text = name;
		image.sprite = tile.sprite;
	}
}
