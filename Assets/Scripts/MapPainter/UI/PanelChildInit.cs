using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PanelChildInit : MonoBehaviour
{
	[SerializeField] UnityEvent OnEnableEvent;
	Image img;

	private void Awake()
	{
		img = GetComponent<Image>();
	}

	private void OnEnable()
	{
		Color col = img.color;
		col.a = 0;
		img.color = col;
		OnEnableEvent?.Invoke();
	}
}
