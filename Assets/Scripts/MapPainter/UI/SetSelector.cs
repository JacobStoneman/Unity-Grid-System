using UnityEngine;

public class SetSelector : MonoBehaviour
{
	SpriteRenderer ren;
	[SerializeField] MapPainterController controller;
	[SerializeField] Sprite hex;
	[SerializeField] Sprite rec;

	private void Awake()
	{
		ren = GetComponent<SpriteRenderer>();
	}

	private void Start()
	{
		UIEvents.current.OnNewMapClicked += NewMapCreated;
		UIEvents.current.OnLoadClicked += LoadMap;
	}

	void LoadMap(string val) => SetSelect();

	void NewMapCreated(string val, string val2) => SetSelect();

	void SetSelect()
	{
		switch (controller.mType)
		{
			case MapType.HEX:
				ren.sprite = hex;
				break;
			case MapType.RECTANGLE:
				ren.sprite = rec;
				break;
		}
	}

	private void OnDestroy()
	{
		UIEvents.current.OnNewMapClicked -= NewMapCreated;
		UIEvents.current.OnLoadClicked -= LoadMap;
	}
}
