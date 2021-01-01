using System.IO;
using UnityEngine;

public class Initialiser : MonoBehaviour
{
	private void Awake()
	{
		//TODO: This should be moved to documents or something
		if (!Directory.Exists($"{Application.dataPath}/Exports"))
		{
			Directory.CreateDirectory($"{Application.dataPath}/Exports");
		}
	}
}
