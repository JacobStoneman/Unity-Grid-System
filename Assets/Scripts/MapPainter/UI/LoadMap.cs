using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadMap : MonoBehaviour
{
	[SerializeField] TMP_Dropdown loadDropdown;
	[SerializeField] StringVariable savePath;
	Button button;

	[SerializeField]string filePath;

	private void Start()
	{
		button = GetComponent<Button>();
		loadDropdown.onValueChanged.AddListener(delegate { SetFilePath(loadDropdown.options[loadDropdown.value].text); });

		if(loadDropdown.options.Count == 0)
		{
			button.interactable = false;
		} else
		{
			SetFilePath(loadDropdown.options[loadDropdown.value].text);
		}
	}

	public void SetFilePath(string path)
	{
		button.interactable = true;
		filePath = $@"{savePath.value}\{path}.json";
	}

	public void Load() => UIEvents.current.LoadClicked(filePath);
}
