using System.IO;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Collections.Generic;

public class Initialiser : MonoBehaviour
{
	[SerializeField] TMP_Dropdown loadDropdown;
	string[] allfiles;
	private void Awake()
	{
		string exportPath = $"{Application.dataPath}/Exports";
		if (!Directory.Exists(exportPath));
		{
			Directory.CreateDirectory(exportPath);
		}

		allfiles = Directory.GetFiles(exportPath, "*.*", SearchOption.AllDirectories);
		List<string> formatted = new List<string>();

		foreach(string str in allfiles)
		{
			if (!str.Contains(".meta"))
			{
				string newStr = str.Replace($@"{exportPath}\", "");
				newStr = newStr.Replace(".json", "");
				formatted.Add(newStr);
			}
		}

		loadDropdown.AddOptions(formatted);
	}
}
