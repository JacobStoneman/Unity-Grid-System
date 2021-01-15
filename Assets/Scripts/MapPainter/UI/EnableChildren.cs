using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableChildren : MonoBehaviour
{
	[SerializeField] List<GameObject> children;
	[SerializeField] GameObject icon;
	private void Start()
	{
		foreach(GameObject child in children)
		{
			child.SetActive(false);
		}
	}

	public void Enable()
	{
		foreach (GameObject child in children)
		{
			child.SetActive(true);
		}
	}

	public void Disable()
	{
		foreach (GameObject child in children)
		{
			child.SetActive(false);
		}
	}

	public void ToggleIcon(bool toggle) => icon.SetActive(toggle);
}
