using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableChildren : MonoBehaviour
{
	private void Start()
	{
		foreach(Transform child in transform)
		{
			child.gameObject.SetActive(false);
		}
	}

	public void Enable()
	{
		foreach (Transform child in transform)
		{
			child.gameObject.SetActive(true);
		}
	}

	public void Disable()
	{
		foreach (Transform child in transform)
		{
			child.gameObject.SetActive(false);
		}
	}
}
