using System.IO;
using UnityEngine;

public class Initialiser : MonoBehaviour
{
	private void Awake()
	{
		if (!Directory.Exists($"{Application.dataPath}/TileSets"))
		{
			Directory.CreateDirectory($"{Application.dataPath}/TileSets");
		}
		if (!Directory.Exists($"{Application.dataPath}/Exports"))
		{
			Directory.CreateDirectory($"{Application.dataPath}/Exports");
		}
	}
}
