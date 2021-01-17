using System.IO;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Collections.Generic;
using System;

public class Initialiser : MonoBehaviour
{
	[SerializeField] StringVariable exportPath;
	string[] allfiles;
	private void Awake()
	{
		exportPath.value = $"{Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents")}/GridBuilder_SaveData";
		if (!Directory.Exists(exportPath.value))
		{
			Directory.CreateDirectory(exportPath.value);
		}
	}

	public void AddOptions(TMP_Dropdown loadDropdown)
	{
		allfiles = Directory.GetFiles(exportPath.value, "*.*", SearchOption.AllDirectories);
		List<string> formatted = new List<string>();

		foreach (string str in allfiles)
		{
			if (!str.Contains(".meta"))
			{
				string newStr = str.Replace($@"{exportPath.value}\", "");
				newStr = newStr.Replace(".json", "");
				formatted.Add(newStr);
			}
		}

		loadDropdown.ClearOptions();
		loadDropdown.AddOptions(formatted);
	}
}
