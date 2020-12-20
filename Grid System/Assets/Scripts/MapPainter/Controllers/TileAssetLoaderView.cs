using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TileAssetLoaderView : MonoBehaviour
{

    [SerializeField] MapPainterController controller;
    [SerializeField] GameObject assetPrefab;
    List<GameObject> assetButtons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        UIEvents.current.OnLoadAssetsClicked += DisplayAssets;
    }

    public void DisplayAssets()
	{
        foreach(GameObject asset in assetButtons)
		{
            Destroy(asset);
		}
        assetButtons.Clear();

        Dictionary<string, Tile> tiles = controller.GetTileAssets();

        foreach(KeyValuePair<string,Tile> pair in tiles)
		{
            GameObject newButton = Instantiate(assetPrefab, transform);
            assetButtons.Add(newButton);
            newButton.GetComponent<OnTileAssetUICreation>().CreateAsset(pair.Key,pair.Value);
		}
	}

	private void OnDestroy()
	{
        UIEvents.current.OnLoadAssetsClicked -= DisplayAssets;
	}
}
