using UnityEngine;

public class CreatePopup : MonoBehaviour
{
	[SerializeField] GameObject PopupObj;
	[SerializeField] Transform Canvas;
	bool popupExists;

	public void CreateNewPopup()
	{
		if (!popupExists)
		{
			GameObject newPopup = Instantiate(PopupObj, Canvas);
			newPopup.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2, Screen.height / 2);
			newPopup.GetComponent<SizeTween>().onCompleteOutCallBack.AddListener(popUpClosed);
			popupExists = true;
		}
	}

	public void popUpClosed() => popupExists = false;
}
