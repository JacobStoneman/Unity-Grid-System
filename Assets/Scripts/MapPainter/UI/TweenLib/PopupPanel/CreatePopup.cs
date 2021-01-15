using UnityEngine;

public class CreatePopup : MonoBehaviour
{
	[SerializeField] GameObject PopupObj;
	[SerializeField] Transform Canvas;

	public void CreateNewPopup()
	{
		GameObject newPopup = Instantiate(PopupObj,Canvas);
		newPopup.GetComponent<RectTransform>().position = new Vector2(Screen.width/2, Screen.height/2);
	}
}
