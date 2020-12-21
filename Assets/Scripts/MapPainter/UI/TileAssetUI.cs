using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TileAssetUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] Image image;
	[SerializeField] Text text;
	[SerializeField] Color SelectedColour;
	[SerializeField] Color UnselectedColour;
	Tile tile;
    bool hover;
	Image self;

    public void OnPointerEnter(PointerEventData eventData) => hover = true;

    public void OnPointerExit(PointerEventData eventData) => hover = false;

	private void Awake()
	{
		self = GetComponent<Image>();
		self.color = UnselectedColour;
	}

	private void Start()
	{
        UIEvents.current.OnTileAssetClicked += OnClick;
	}

	void OnClick(GameObject asset)
	{

		if (asset == gameObject)
		{
			self.color = SelectedColour;
			UIEvents.current.NewTileSet(tile);
		}
		else
		{
			self.color = UnselectedColour;
		}
	}

	public void CreateAsset(string name, Tile _tile)
	{
		text.text = name;
		image.sprite = _tile.sprite;
		tile = _tile;
	}

	private void OnDestroy()
	{
        UIEvents.current.OnTileAssetClicked -= OnClick;
	}
}
